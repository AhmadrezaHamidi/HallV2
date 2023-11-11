using Autofac;
using Autofac.Core;
using Framework.Autofac;
using Framework.Domain;
using Framework.EntityFrameworkCore;
using Hall.Application.CommandHandlers;
using Hall.Domain;
using Hall.Domain.Models.Categories;
using Hall.Infrastructure.Persistence.Sql;
using Hall.Infrastructure.Persistence.Sql.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hall.Config;

public class AutofacModule:BaseModule
{
     private readonly BaseConfig _config;
        public AutofacModule(BaseConfig config) : base(typeof(CategoryRepository).Assembly,
            typeof(CategoryCommandHandler).Assembly)
        {
            _config = config;
        }
        protected override void CustomRegister(ContainerBuilder builder)
        {
            builder.RegisterType<RequestContext>().As<IRequestContext>().SingleInstance();
            //register unit of work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //register Services

            builder.Register(c => _config).As<BaseConfig>().SingleInstance();

            var optionBuilder = new DbContextOptionsBuilder<DataBaseContext>()
                .UseSqlServer(_config.ConnectionString);

            builder.RegisterType(typeof(DataBaseContext))
                .WithParameter("options", optionBuilder.Options)
                .As<DbContext>()
                .Keyed<DataBaseContext>("Command")
                .InstancePerLifetimeScope()
                .OnRelease(x => { });
            builder.RegisterType<EventAggregator>()
                .As<IEventPublisher>()
                .As<IEventListener>()
                .InstancePerLifetimeScope()
                .OnRelease(x => { });
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(DataBaseContext),
                    (pi, ctx) => ctx.ResolveKeyed<DataBaseContext>("Command")))
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType == typeof(ICategoryRepository)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .OnRelease(x => { });
        }
}