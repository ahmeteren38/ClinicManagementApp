using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Appointment.GetAppointmentById
{
    public class GetAppointmentByIdQueryResponse
    {
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int DiseaseId { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
