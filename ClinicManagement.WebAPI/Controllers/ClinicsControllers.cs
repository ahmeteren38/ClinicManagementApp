using ClinicManagement.Application.Features.Command.Clinic.AddClinic;
using ClinicManagement.Application.Features.Command.Clinic.DeleteClinic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsControllers : ControllerBase
    {
        readonly IMediator _mediator;

        public ClinicsControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddClinic(AddClinicCommandRequest addClinicCommandRequest)
        {
          AddClinicCommandResponse response = await _mediator.Send(addClinicCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClinic(DeleteClinicCommandRequest deleteClinicCommandRequest)
        {
            DeleteClinicCommandResponse response = await _mediator.Send(deleteClinicCommandRequest);
            return Ok(response);
        }
    }
}
