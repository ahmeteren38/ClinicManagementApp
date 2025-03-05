using ClinicManagement.Application.Features.Command.Appointment.AddAppointment;
using ClinicManagement.Application.Features.Command.Appointment.DeleteAppointment;
using ClinicManagement.Application.Features.Command.Appointment.UpdateAppointment;
using ClinicManagement.Application.Features.Query.Appointment.GetAllAppointments;
using ClinicManagement.Application.Features.Query.Appointment.GetAppointmentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAppointment([FromBody] AddAppointmentCommandRequest addAppointmentCommandRequest)
        {
            AddAppointmentCommandResponse response = await _mediator.Send(addAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAppointment([FromQuery] DeleteAppointmentCommandRequest deleteAppointmentCommandRequest)
        {
            DeleteAppointmentCommandResponse response = await _mediator.Send(deleteAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentCommandRequest updateAppointmentCommandRequest)
        {
            UpdateAppointmentCommandResponse response = await _mediator.Send(updateAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await _mediator.Send(new GetAllAppointmentsQueryRequest());
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAppointmentById([FromQuery] GetAppointmentByIdQueryRequest getAppointmentByIdQueryRequest)
        {
           GetAppointmentByIdQueryResponse response = await _mediator.Send(getAppointmentByIdQueryRequest);
            return Ok(response);
        }
    }
}
