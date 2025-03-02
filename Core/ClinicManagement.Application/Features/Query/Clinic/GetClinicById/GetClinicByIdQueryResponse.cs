using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Clinic.GetClinicById
{
    public class GetClinicByIdQueryResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string GSM { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
