using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.AddPatient
{
    public class AddPatientCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
