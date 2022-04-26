using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand  // Implementa desde que seja ICommand
    {
        ICommandResult Handle(T command);
    }
}