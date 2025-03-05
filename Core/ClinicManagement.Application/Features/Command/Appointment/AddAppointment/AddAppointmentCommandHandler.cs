using ClinicManagement.Application.Constans;
using ClinicManagement.Application.DTOs.Appointment;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Appointment.AddAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommandRequest, AddAppointmentCommandResponse>
    {
        readonly IPatientReadRepository _petientReadRepository;
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IDiseaseReadRepository _diseaseReadRepository;
        readonly IAppointmentWriteRepository _appointmentWriteRepository;
        readonly IAppointmentReadRepository _appointmentReadRepository;

        public AddAppointmentCommandHandler(IAppointmentWriteRepository appointmentWriteRepository,
            IPatientReadRepository petientReadRepository,
            IClinicReadRepository clinicReadRepository,
            IDiseaseReadRepository diseaseReadRepository,
            IEmployeeReadRepository employeeReadRepository,
            IAppointmentReadRepository appointmentReadRepository)
        {
            _appointmentWriteRepository = appointmentWriteRepository;
            _petientReadRepository = petientReadRepository;
            _clinicReadRepository = clinicReadRepository;
            _diseaseReadRepository = diseaseReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _appointmentReadRepository = appointmentReadRepository;
        }

        public async Task<AddAppointmentCommandResponse> Handle(AddAppointmentCommandRequest request, CancellationToken cancellationToken)
        {

            var patient = await _petientReadRepository.GetAll().Where(p => p.Id.Equals(request.PatientId)).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

            var employee = await _employeeReadRepository.GetAll().Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotFind);
            }

            var disease = await _diseaseReadRepository.GetAll().Where(d => d.Id == request.DiseaseId).FirstOrDefaultAsync();
            if (disease == null) 
            {
                throw new Exception(BussinessConstants.DiseaseCouldNotFind);
            }

            var lastAppointment = await _appointmentReadRepository.GetAll().OrderByDescending(a => a.Id).FirstOrDefaultAsync();

            int newAppointmentId = lastAppointment != null ? lastAppointment.Id + 1 : 1;

            var result = await _appointmentWriteRepository.AddAsync(new()
            {
                AppointmentDate = request.AppointmentDate,
                PatientId = request.PatientId,
                ClinicId = request.ClinicId,
                Description = request.Description,
                EmployeeId = request.EmployeeId,
                DiseaseId = request.DiseaseId
            });

            if (result == null)
            {
                throw new Exception(BussinessConstants.AppointmentCouldNotAdd);
            }

            await _appointmentWriteRepository.SaveAsync();
            return new() 
            { 
                Message = BussinessConstants.AppointmentSuccessfullyCreated,
                Succeeded = true,
                AppointmentId = newAppointmentId,
            };
        }
    }
}
