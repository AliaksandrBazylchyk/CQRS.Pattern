using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.BLL.Services.Person;
using CQRS.Pattern.Commands.Person;
using CQRS.Pattern.Models;
using CQRS.Pattern.Queries.Person;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPersonService _personService;

        public TestController(
            IMediator mediator,
            IPersonService personService
        )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<DataWithTotal<PersonDto>>> Get([FromQuery] GetPersonQuery query,
            CancellationToken token) =>
            Ok(await _mediator.Send(query, token));

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll(CancellationToken token)
        {
            var result = await _personService.GetAllPersonsAsync();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] AddPersonCommand client,
            CancellationToken token)
        {
            var entity = await _mediator.Send(client, token);

            return Ok(entity);
        }
    }
}