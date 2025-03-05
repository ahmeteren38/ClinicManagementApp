using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.DeletePatient
{
    public class DeletePatientCommandResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
