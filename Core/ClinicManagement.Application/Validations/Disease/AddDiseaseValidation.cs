using ClinicManagement.Application.Features.Command.Disease.AddDisease;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Disease
{
    public class AddDiseaseValidation : AbstractValidator<AddDiseaseCommandRequest>
    {
        public AddDiseaseValidation()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Disease name can not be empty!");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description can not be empty!");

            RuleFor(d => d.PatientId)
                .NotEmpty().WithMessage("Patient can not be empty!");
        }
    }
}
