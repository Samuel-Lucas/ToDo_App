using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class ToDoQueriesTests
    {
        private List<ToDoItem> _items;

        public ToDoQueriesTests()
        {
            _items = new List<ToDoItem>();
            _items.Add(new ToDoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new ToDoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new ToDoItem("Tarefa 3", "samuellucas", DateTime.Now));
            _items.Add(new ToDoItem("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new ToDoItem("Tarefa 5", "samuellucas", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_samuellucas()
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetAll("samuellucas"));
            Assert.AreEqual(2, result.Count());
        }
    }
}