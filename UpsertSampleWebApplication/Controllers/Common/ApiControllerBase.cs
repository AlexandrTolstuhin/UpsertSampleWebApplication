using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UpsertSampleWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}