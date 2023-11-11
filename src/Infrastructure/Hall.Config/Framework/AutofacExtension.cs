using System.Reflection;
using Autofac;
using Framework.Application;

namespace Framework.Autofac;

public static class AutofacExtension
{

    public static void RegisterRepositories(this ContainerBuilder builder, Assembly assembly)
                                                                          => builder.RegisterAssemblyTypes(assembly)
                                                                              .Where(t => t.Name.EndsWith("Repository"))
                                                                              .AsImplementedInterfaces().InstancePerLifetimeScope();

    public static void RegisterBus(this ContainerBuilder builder)
    {
        builder.RegisterType<AutofacCommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
        builder.RegisterType<AutofacQueryBus>().As<IQueryBus>().InstancePerLifetimeScope();
    }
    public static void RegisterHandlers(this ContainerBuilder builder,Assembly assembly)
    {
        builder.RegisterAssemblyTypes(assembly)
            .As(type => type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(assembly)
            .As(type => type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IQueryHandler<,>))))
            .InstancePerLifetimeScope();
    }
}
