using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<ToDoItem> GetAll(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetAll("samuellucas");
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody]CreateToDoCommand command,
            [FromServices]ToDoHandler handler)
        {
            command.User = "samuellucas";
            return (GenericCommandResult)handler.Handle(command);
        } 
    }
}