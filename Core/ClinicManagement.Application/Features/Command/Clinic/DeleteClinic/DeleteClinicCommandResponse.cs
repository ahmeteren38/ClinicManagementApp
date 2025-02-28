using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.DeleteClinic
{
    public class DeleteClinicCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
