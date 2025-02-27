using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTOs.Appointment
{
    public class AddAppointmentRequestDTO
    {
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }

    }
}
