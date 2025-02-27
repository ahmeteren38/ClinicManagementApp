using ClinicManagement.Application.Features.Command.Appointment.AddAppointment;
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
    }
}
