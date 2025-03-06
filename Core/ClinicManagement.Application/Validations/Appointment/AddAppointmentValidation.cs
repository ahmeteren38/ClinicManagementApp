using ClinicManagement.Application.Features.Command.Appointment.AddAppointment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Validations.Appointment
{
    public class AddAppointmentValidation : AbstractValidator<AddAppointmentCommandRequest>
    {
        public AddAppointmentValidation()
        {
            RuleFor(c => c.AppointmentDate)
                .NotEmpty().WithMessage("Appointment Date can not be empty!");

            RuleFor(c => c.PatientId)
                .NotEmpty().WithMessage("Patient can not be empty!");

            RuleFor(c => c.ClinicId)
                .NotEmpty().WithMessage("Clinic can not be empty!");

            RuleFor(c => c.EmployeeId)
                .NotEmpty().WithMessage("Employee can not be empty!");

            RuleFor(c => c.DiseaseId)
                .NotEmpty().WithMessage("Disease can not be empty!");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description can not be empty!");
        }
    }
}
