using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [Route("done")]
        public IEnumerable<ToDoItem> GetAllDone(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetAllDone("samuellucas");
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<ToDoItem> GetAllUndone(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetAllUndone("samuellucas");
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<ToDoItem> GetAllDoneToday(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetByPeriod("samuellucas", DateTime.Now.Date, true);
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<ToDoItem> GetAllUndoneToday(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetByPeriod("samuellucas", DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<ToDoItem> GetAllDoneTomorrow(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetByPeriod("samuellucas", DateTime.Now.Date.AddDays(1), true);
        } 

        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<ToDoItem> GetAllUndoneTomorrow(
            [FromServices]IToDoRepository repository)
        {
            return repository.GetByPeriod("samuellucas", DateTime.Now.Date.AddDays(1), false);
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

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody]UpdateToDoCommand command,
           [FromServices]ToDoHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_guid")?.Value;
            // command.User = User.Claims.Where(x => x.Type == "user_id").Select(x => x.Value).FirstOrDefault();
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody]MarkToDoAsDoneCommand command,
            [FromServices]ToDoHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody]MarkToDoAsDoneCommand command,
            [FromServices]ToDoHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}