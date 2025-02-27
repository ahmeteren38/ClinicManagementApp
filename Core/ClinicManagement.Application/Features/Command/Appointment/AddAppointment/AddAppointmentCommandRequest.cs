using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Appointment.AddAppointment
{
    public class AddAppointmentCommandRequest : IRequest<AddAppointmentCommandResponse>
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
