using ClinicManagement.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Appointment.AddAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommandRequest, AddAppointmentCommandResponse>
    {
        IAppointmentService _appointmentService;

        public AddAppointmentCommandHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AddAppointmentCommandResponse> Handle(AddAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
           await _appointmentService.AddAppointment(new()
           {
               AppointmentDate = request.AppointmentDate,
           });
            return new();
        }
    }
}
