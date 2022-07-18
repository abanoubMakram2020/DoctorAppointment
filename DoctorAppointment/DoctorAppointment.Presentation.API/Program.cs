using Autofac;
using Autofac.Extensions.DependencyInjection;
using DoctorAppointment.Infrastructure;
using DoctorAppointment.Infrastructure.DependencyResolution;
using DoctorAppointment.Presentation.API.Controllers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Configuration.Initialize();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().PropertiesAutowired().SingleInstance();
    DependencyResolutionFacade.Initialize(container: builder);
    #region Register Controller For Property DI
    System.Type controllerBaseType = typeof(BaseController);
    builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType).PropertiesAutowired();
    #endregion
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.Initialize();
IHttpContextAccessor httpContextAccessor = builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();
builder.Services.CommonAPIConfigurations(httpContextAccessor: httpContextAccessor);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.Initialize();
app.Run();
