using ClinicManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
