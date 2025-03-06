using ClinicManagement.Application.Features.Command.Clinic.UpdateClinic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Clinic
{
    public class UpdateClinicValidation : AbstractValidator<UpdateClinicCommandRequest>
    {
        public UpdateClinicValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can not be empty!")
                .MinimumLength(3).WithMessage("Name must be more than 3 characters");

            RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Clinic address can not be empty!");

            RuleFor(c => c.City)
            .NotEmpty().WithMessage("Clinic city can not be empty!");

            RuleFor(c => c.GSM)
            .NotEmpty().WithMessage("GSM cannot be empty")
            .Matches(@"^\+?[1-9][0-9]{7,14}$").WithMessage("Invalid phone number format");
        }
    }
}
