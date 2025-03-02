using ClinicManagement.Application.Features.Command.Clinic.AddClinic;
using ClinicManagement.Application.Features.Command.Clinic.DeleteClinic;
using ClinicManagement.Application.Features.Command.Clinic.UpdateClinic;
using ClinicManagement.Application.Features.Query.Clinic.GetAllClinics;
using ClinicManagement.Application.Features.Query.Clinic.GetClinicById;
using MediatR;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddClinic(AddClinicCommandRequest addClinicCommandRequest)
        {
          AddClinicCommandResponse response = await _mediator.Send(addClinicCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteClinic(DeleteClinicCommandRequest deleteClinicCommandRequest)
        {
            DeleteClinicCommandResponse response = await _mediator.Send(deleteClinicCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateClinic(UpdateClinicCommandRequest updateClinicCommandRequest)
        {
          UpdateClinicCommandResponse response = await _mediator.Send(updateClinicCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllClinics()
        {
            var response = await _mediator.Send(new GetAllClinicsQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetClinicById([FromQuery] GetClinicByIdQueryRequest getClinicByIdQueryRequest)
        {
            GetClinicByIdQueryResponse response = await _mediator.Send(getClinicByIdQueryRequest);
            return Ok(response);
        }
    }
}
