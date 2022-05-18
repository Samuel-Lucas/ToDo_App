using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class ToDoHandler : 
    Notifiable,
    IHandler<CreateToDoCommand>, 
    IHandler<UpdateToDoCommand>, 
    IHandler<MarkToDoAsDoneCommand>, 
    IHandler<MarkToDoAsUndoneCommand>
    {
        private readonly IToDoRepository _repository;

        public ToDoHandler(IToDoRepository repository)
        {
            _repository = repository;
        }
        
        public ICommandResult Handle(CreateToDoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            // Gera o todo item
            var todo = new ToDoItem(command.Title, command.User, command.Date);

            // Salvar no banco
            _repository.Create(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva !", todo);
        }

        public ICommandResult Handle(UpdateToDoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);
                
            // Fazer função para pegar user

            // Recupera o ToDoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salva alteração no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva !", todo);
        }

        public ICommandResult Handle(MarkToDoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva !", todo);
        }

        public ICommandResult Handle(MarkToDoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);
            
            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva !", todo);
        }
    }
}