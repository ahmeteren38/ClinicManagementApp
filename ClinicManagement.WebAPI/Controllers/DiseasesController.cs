using ClinicManagement.Application.Features.Command.Disease.AddDisease;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        readonly IMediator _mediator;

        public DiseasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddDisease(AddDiseaseCommandRequest addDiseaseCommandRequest)
        {
          AddDiseaseCommandResponse response = await _mediator.Send(addDiseaseCommandRequest);
            return Ok(response);
        }
    }
}
