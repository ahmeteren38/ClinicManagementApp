using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? UpdateAppointment { get; set; }
        public DateTime? DeleteAppointment { get; set; }
        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

    }
}
