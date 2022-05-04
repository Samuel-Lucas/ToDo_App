using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class ToDoItemTests
    {
        private readonly ToDoItem _validToDo = new ToDoItem("Titulo aqui", "samuellucas", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_to_do_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validToDo.Done, false);
        }
    }
}