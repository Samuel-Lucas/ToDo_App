using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ToDoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
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
            _context.Entry(todo).State = EntityState.Modified;  // Objeto foi modificado, altera só o que foi mudado
            _context.SaveChanges();
        }
    }
}