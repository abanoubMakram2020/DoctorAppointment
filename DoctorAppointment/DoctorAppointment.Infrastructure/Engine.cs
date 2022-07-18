using AutoMapper;
using DoctorAppointment.Infrastructure.SQLContext;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using SharedKernal.Common;
using SharedKernal.Common.Configuration;
using SharedKernal.Middlewares.Exception;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.Swagger;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace DoctorAppointment.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string[] AllowedOrigins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public static void Initialize(this IConfiguration configuration)
        {

            var _databaseConfiguration = new DatabaseConfiguration();
            configuration.Bind(nameof(DatabaseConfiguration), _databaseConfiguration);

            var _swaggerSettings = new SwaggerSettings();
            configuration.Bind(nameof(SwaggerSettings), _swaggerSettings);

            var _jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), _jwtSettings);

            var _commonConfigurations = new CommonConfigurations();
            configuration.Bind(nameof(CommonConfigurations), _commonConfigurations);

            var _eventBusSettings = new EventBusSettings();
            configuration.Bind(nameof(EventBusSettings), _eventBusSettings);

            var _healthCheckSettings = new HealthCheckSettings();
            configuration.Bind(nameof(HealthCheckSettings), _healthCheckSettings);

            var _APIsConfigurations = new APIsConfigurations();
            configuration.Bind(nameof(APIsConfigurations), _APIsConfigurations);

            IConfigurationSection originsSection = configuration.GetSection("AllowedOrigins");
            AllowedOrigins = originsSection.AsEnumerable().Where(s => s.Value != null).Select(a => a.Value).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void Initialize(this IServiceCollection service)
        {
            service.AddControllers()
                   .AddControllersAsServices();
            service.AddOptions();

            #region DbContext & Identity
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new DbContextInterceptor());
                options.UseSqlServer(DatabaseConfiguration.ConnectionString);
                options.EnableSensitiveDataLogging();
            }, optionsLifetime: ServiceLifetime.Scoped);

            #endregion

            #region AllowedOrigins
            service.AddCors(options =>
            {
                options.AddPolicy(nameof(AllowedOrigins), builder => builder.WithOrigins(AllowedOrigins).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            #endregion

            service.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            #region App localization
            service.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedCultures = new System.Collections.Generic.List<CultureInfo> { new CultureInfo("en"), new CultureInfo("ar") };

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? "ar" : firstLang;
                    return Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            #endregion

            #region Authentication
            service.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = JwtSettings.RequireExpirationTime,
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidAudience = JwtSettings.ValidAudience,
                    ValidIssuer = JwtSettings.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecurityKey))
                };
            });
            #endregion

            #region AutoMapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new Mapper.StructureMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            #endregion

            //service.CommonAPIConfigurations();

            #region MassTransit-RabbitMQ Configuration
            service.AddMassTransit(config =>
            {
                //config.AddRequestClient<CreateRequestInputDTO>();
                //config.AddRequestClient<UpdateActionRequestInputDTO>();
                config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(bus =>
                {
                    bus.Host(host: EventBusSettings.HostIpAddress, port: EventBusSettings.HostPort, virtualHost: "/", connectionName: string.Empty, configure: host =>
                    {
                        host.Username(EventBusSettings.Username);
                        host.Password(EventBusSettings.Password);
                    });
                }));
            });
            service.AddMassTransitHostedService();

            #endregion MassTransit-RabbitMQ Configuration

            #region Health Checks
            service.AddHealthChecks()
                   .AddSqlServer(name: "SQLServer-check",
                                 connectionString: DatabaseConfiguration.ConnectionString,
                                 healthQuery: "Select 1;",
                                 failureStatus: HealthStatus.Unhealthy,
                                 tags: new string[] { "SQLServer" })

                   .AddRabbitMQ(name: "RabbitMQ-check",
                                rabbitConnectionString: $"amqp://{EventBusSettings.HostIpAddress}:{EventBusSettings.HostPort}",
                                failureStatus: HealthStatus.Unhealthy,
                                tags: new string[] { "RabbitMQ" });

            #endregion

            service.AddSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version, description: SwaggerSettings.Description);
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddMemoryCache();
            service.AddHttpContextAccessor();
            service.AddHttpClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void Initialize(this IApplicationBuilder app)
        {
            //Container = app.ApplicationServices;

            app.UseSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version);

            app.UseMiddleware<ExceptionHandler>();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();

            #region Health Checks
            // default endpoint: /healthmetrics
            //app.UseHealthChecksPrometheusExporter();

            // You could customize the endpoint
            app.UseHealthChecksPrometheusExporter("/healthchecks");

            // Customize HTTP status code returned(prometheus will not read health metrics when a default HTTP 503 is returned)
            app.UseHealthChecksPrometheusExporter("/healthchecks", options => options.ResultStatusCodes[HealthStatus.Unhealthy] = (int)HttpStatusCode.OK);
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void CommonAPIConfigurations(this IServiceCollection service, IHttpContextAccessor httpContextAccessor)
        {
            service.AddHttpClient(name: APIsConfigurations.CommonAPI.APIName, configureClient: client =>
            {
                string parameter = string.Empty;
                if (httpContextAccessor.HttpContext is not null && httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    var header = AuthenticationHeaderValue.Parse(httpContextAccessor?.HttpContext?.Request?.Headers["Authorization"]);
                    if (header != null)
                        parameter = header.Parameter;
                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri($"{APIsConfigurations.GatewayBaseURL}/{APIsConfigurations.CommonAPI.Version}/{APIsConfigurations.CommonAPI.APIName}/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeType.ApplicationJson));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-type", MimeType.ApplicationJson);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"basic {parameter}");
            }).ConfigurePrimaryHttpMessageHandler((c) =>
            {
                var clientCertificates = new X509Certificate2Collection();
                var handler = new HttpClientHandler()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12,
                };
                handler.ClientCertificates.AddRange(clientCertificates);
                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                return handler;
            });
        }

    }

}