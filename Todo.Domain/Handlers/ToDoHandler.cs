using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class ToDoHandler : Notifiable, IHandler<CreateToDoCommand>
    {
        private readonly IToDoRepository _repository;

        public ToDoHandler(IToDoRepository repository)
        {
            _repository = _repository;
        }
        
        public ICommandResult Handle(CreateToDoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua terefa está errada", command.Notifications);
        }
    }
}