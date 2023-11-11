

namespace Framework.Application
{
    public interface ICommandBus
    {
        Task<CommandResult> Dispatch<T>(T command) where T : ICommand;
    }
}
