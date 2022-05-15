using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        public void Create(ToDoItem todo)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}