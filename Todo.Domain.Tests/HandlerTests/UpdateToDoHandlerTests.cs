using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateToDoHandlerTests
    {
        private readonly UpdateToDoCommand _invalidCommand = new UpdateToDoCommand(default, "", "");
        private readonly UpdateToDoCommand _validCommand = new UpdateToDoCommand(new Guid(), "Titulo", "samuellucas");
        private readonly ToDoHandler _handler = new ToDoHandler(new FakeToDoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public UpdateToDoHandlerTests()
        {

        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Sucesso, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Sucesso, true);
        }
    }
}