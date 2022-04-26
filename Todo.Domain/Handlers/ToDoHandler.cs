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
            throw new System.NotImplementedException();
        }
    }
}