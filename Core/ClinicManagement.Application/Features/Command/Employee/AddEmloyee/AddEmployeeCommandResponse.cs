﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.AddEmloyee
{
    public class AddEmployeeCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int EmployeeId { get; set; }
    }
}
