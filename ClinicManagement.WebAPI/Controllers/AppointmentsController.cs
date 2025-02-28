using ClinicManagement.Application.Features.Command.Appointment.AddAppointment;
using ClinicManagement.Application.Features.Command.Appointment.DeleteAppointment;
using ClinicManagement.Application.Features.Command.Appointment.UpdateAppointment;
using ClinicManagement.Application.Features.Query.Appointment.GetAllAppointments;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AddAppointmentCommandRequest addAppointmentCommandRequest)
        {
          AddAppointmentCommandResponse response = await _mediator.Send(addAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(DeleteAppointmentCommandRequest deleteAppointmentCommandRequest)
        {
           DeleteAppointmentCommandResponse response = await _mediator.Send(deleteAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommandRequest updateAppointmentCommandRequest)
        {
           UpdateAppointmentCommandResponse response = await _mediator.Send(updateAppointmentCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await _mediator.Send(new GetAllAppointmentsQueryRequest());
            return Ok();
        }
    }
}
