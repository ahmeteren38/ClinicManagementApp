using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.AddPatient
{
    public class AddPatientCommandRequest : IRequest<AddPatientCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ClinicId { get; set; }
    }
}
