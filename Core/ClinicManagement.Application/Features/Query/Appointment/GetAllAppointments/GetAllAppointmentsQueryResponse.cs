using ClinicManagement.Application.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Appointment.GetAllAppointments
{
    public class GetAllAppointmentsQueryResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<GetAllAppointmentsResponseDTO> Appointments { get; set; }
    }
}
