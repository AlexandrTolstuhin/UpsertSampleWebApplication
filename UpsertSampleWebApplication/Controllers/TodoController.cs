using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpsertSampleWebApplication.Command;
using UpsertSampleWebApplication.Queries;

namespace UpsertSampleWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await _mediator.Send(new GetAllTodosQuery()));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertTodoCommand command) => 
            Ok(await _mediator.Send(command));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] UpdateTodoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(command));
        }
    }
}