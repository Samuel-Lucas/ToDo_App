using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeToDoRepository : IToDoRepository
    {
        public void Create(ToDoItem todo)
        {
            
        }

        public IEnumerable<ToDoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public ToDoItem GetById(Guid Id, string user)
        {
            return new ToDoItem("Titulo aqui", "samuellucas", DateTime.Now);
        }

        public IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoItem todo)
        {
            
        }
    }
}