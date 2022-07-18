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

         

            #region AutoMapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new Mapper.StructureMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
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


            app.UseSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version);

            app.UseMiddleware<ExceptionHandler>();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();

    
            app.UseCors(nameof(AllowedOrigins));
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
  

    }

}