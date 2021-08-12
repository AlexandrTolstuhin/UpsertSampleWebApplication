using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpsertSampleWebApplication.Command;
using UpsertSampleWebApplication.Queries;

namespace UpsertSampleWebApplication.Controllers
{
    public class TodoController : ApiControllerBase
    {
        public TodoController(IMediator mediator) 
            : base(mediator)
        { }
        
        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await Mediator.Send(new GetAllTodosQuery()));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertTodoCommand command) => 
            Ok(await Mediator.Send(command));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTodoCommand command) =>
            id == command.Id
                ? Ok(await Mediator.Send(command))
                : BadRequest();
    }
}