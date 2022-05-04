using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface IToDoRepository
    {
        void Create(ToDoItem todo);
        void Update(ToDoItem todo);
        ToDoItem GetById(Guid Id, string user);
    }
}