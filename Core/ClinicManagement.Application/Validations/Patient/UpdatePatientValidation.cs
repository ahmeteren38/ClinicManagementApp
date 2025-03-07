using ClinicManagement.Application.Features.Command.Patient.UpdatePatient;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Patient
{
    public class UpdatePatientValidation : AbstractValidator<UpdatePatientCommandRequest>
    {
        public UpdatePatientValidation()
        {
            RuleFor(p => p.PatientId)
                .NotEmpty().WithMessage("Patient can not be empty!");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Patient name can not be empty!");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("Patient surname can not be empty!");

            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage("Patient identity number can not be empty!")
                .Length(11).WithMessage("Patient identity number must be 11 characters!")
                .Matches(@"^[0-9]{11}$").WithMessage("Patient identity number must have numbers!");

            RuleFor(p => p.Birthday)
                .NotEmpty().WithMessage("Patient birthday can not be empty!");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description can not be empty!");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("Patient gender can not be empty!");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can not be empty")
            .Matches(@"^\+?[1-9][0-9]{7,14}$").WithMessage("Invalid phone number format");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address can not be empty!");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email can not be empty!");

            RuleFor(p => p.ClinicId)
                .NotEmpty().WithMessage("Clinic can not be empty!");
        }
    }
}
