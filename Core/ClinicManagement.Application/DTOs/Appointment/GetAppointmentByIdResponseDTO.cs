using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTOs.Appointment
{
    public class GetAppointmentByIdResponseDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
