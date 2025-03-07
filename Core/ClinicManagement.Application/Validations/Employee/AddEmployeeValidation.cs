using ClinicManagement.Application.Features.Command.Employee.AddEmloyee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Employee
{
    public class AddEmployeeValidation : AbstractValidator<AddEmployeeCommandRequest>
    {
        public AddEmployeeValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Employee name can not be empty!");

            RuleFor(e => e.Surname)
                .NotEmpty().WithMessage("Employee surname can not be empty!");

            RuleFor(e => e.IdentityNumber)
                .NotEmpty().WithMessage("Employee identity number can not be empty!").Length(11).WithMessage("Employee identity number must be 11 characters!").Matches(@"^[0-9]{11}$").WithMessage("Employee identity number must have numbers!");

            RuleFor(e => e.Birthday)
                .NotEmpty().WithMessage("Employee birthday can not be empty!");

            RuleFor(e => e.Job)
                .NotEmpty().WithMessage("Employee job can not be empty");

            RuleFor(e => e.ClinicId)
                .NotEmpty().WithMessage("Clinic can not be empty!");

        }
    }
}
