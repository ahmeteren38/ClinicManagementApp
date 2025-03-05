using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.AddClinic
{
    public class AddClinicCommandResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int ClinicId { get; set; }

    }
}
