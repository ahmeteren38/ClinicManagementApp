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
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int DiseaseId { get; set; }
    }
}
