using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeToDoRepository : IToDoRepository
    {
        public void Create(ToDoItem todo)
        {
            
        }

        public ToDoItem GetById(Guid Id, string user)
        {
            return new ToDoItem("Titulo aqui", "samuellucas", DateTime.Now);
        }

        public void Update(ToDoItem todo)
        {
            
        }
    }
}