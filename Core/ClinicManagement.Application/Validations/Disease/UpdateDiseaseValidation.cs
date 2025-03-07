using ClinicManagement.Application.Features.Command.Disease.UpdateDisease;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Disease
{
    public class UpdateDiseaseValidation : AbstractValidator<UpdateDiseaseCommandRequest>
    {
        public UpdateDiseaseValidation()
        {
            RuleFor(d => d.DiseaseId)
                .NotEmpty().WithMessage("Disease can not be empty!");

            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Disease name can not be empty!");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description can not be empty!");

            RuleFor(d => d.PatientId)
                .NotEmpty().WithMessage("Patient can not be empty!");
        }
    }
}
