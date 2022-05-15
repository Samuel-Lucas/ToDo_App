using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface IToDoRepository
    {
        void Create(ToDoItem todo);
        void Update(ToDoItem todo);
        ToDoItem GetById(Guid Id, string user);

        IEnumerable<ToDoItem> GetAll(string user);
        IEnumerable<ToDoItem> GetAllDone(string user);
        IEnumerable<ToDoItem> GetAllUndone(string user);
        IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done);
    }
}