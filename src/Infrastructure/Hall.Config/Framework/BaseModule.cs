 using System.Reflection;
using Autofac;
using Module = Autofac.Module;


namespace Framework.Autofac;

public abstract class BaseModule: Module
{
    public Assembly RepositoryAssembly { get;private set; }
    public Assembly HandlerAssembly{ get;private set; }
    protected BaseModule(Assembly repositoryAssembly, Assembly handlerAssembly)
    {
        RepositoryAssembly = repositoryAssembly;
        HandlerAssembly = handlerAssembly;
    }
    protected override void Load(ContainerBuilder builder)
    {
        //register repositories
        builder.RegisterRepositories(RepositoryAssembly);
        
        //register command bus
        builder.RegisterBus();

        //register query handlers
        builder.RegisterHandlers(HandlerAssembly);

        CustomRegister(builder);
    }
    protected abstract void CustomRegister(ContainerBuilder builder);
}