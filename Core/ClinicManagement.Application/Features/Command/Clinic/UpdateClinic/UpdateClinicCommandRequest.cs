using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.UpdateClinic
{
    public class UpdateClinicCommandRequest : IRequest<UpdateClinicCommandResponse>
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string GSM { get; set; }
    }
}
