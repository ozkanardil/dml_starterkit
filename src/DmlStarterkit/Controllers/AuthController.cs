using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DmlStarterkit.Application.Features.Auth.Models;
using DmlStarterkit.Infrastructure.Results;
using DmlStarterkit.Application.Features.Auth.Queries;
using DmlStarterkit.Application.Features.Auth.Commands;

namespace DmlStarterkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(IRequestDataResult<LoginResponse>))]
        public async Task<IActionResult> PostAsync([FromBody] GetLoginQuery request)
        {
            var res = await _mediator.Send(request);
            if (res.Success)
                return Ok(res);

            return BadRequest(res);
        }

    }
}
