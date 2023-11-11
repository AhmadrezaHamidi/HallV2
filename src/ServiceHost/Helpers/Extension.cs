using Autofac;
using Autofac.Extensions.DependencyInjection;
using Framework.Autofac;
using Hall.Config;
using Hall.Infrastructure.Persistence.Sql;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost.Helpers;

public static class Extension
{
    public static void AddDatabase(this WebApplicationBuilder builder)
        => builder.Services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
    public static void AddAllCors(this WebApplicationBuilder builder)=>builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            builders =>
            {
                builders.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
    });

    public static void AddAutofac(this WebApplicationBuilder builder,string[]args, BaseConfig config)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutofacModule(config)));
        Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory());
        var autofac = new ContainerBuilder();
        autofac.RegisterModule(new AutofacModule(config));
    }
   
}