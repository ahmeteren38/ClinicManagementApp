using ClinicManagement.Application.Features.Command.Patient.AddPatient;
using ClinicManagement.Application.Features.Command.Patient.DeletePatient;
using ClinicManagement.Application.Features.Command.Patient.UpdatePatient;
using ClinicManagement.Application.Features.Query.Patient.GetAllPatients;
using ClinicManagement.Application.Features.Query.Patient.GetPatientById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPatient([FromBody] AddPatientCommandRequest addPatientCommandRequest)
        {
          AddPatientCommandResponse response = await _mediator.Send(addPatientCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePatient([FromQuery] DeletePatientCommandRequest deletePatientCommandRequest)
        {
          DeletePatientCommandResponse response = await _mediator.Send(deletePatientCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientCommandRequest updatePatientCommandRequest)
        {
          UpdatePatientCommandResponse response = await _mediator.Send(updatePatientCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _mediator.Send(new GetAllPatientsQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPatientById([FromQuery] GetPatientByIdQueryRequest getPatientByIdQueryRequest)
        {
          GetPatientByIdQueryResponse response = await _mediator.Send(getPatientByIdQueryRequest);
            return Ok(response);
        }
    } 
}
