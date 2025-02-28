using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Application.Features.Command.Appointment.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, UpdateAppointmentCommandResponse>
    {
        readonly IAppointmentReadRepository _appointmentReadRepository;
        readonly IAppointmentWriteRepository _appointmentWriteRepository;
        readonly IPatientReadRepository _patientReadRepository;
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IDiseaseReadRepository _diseaseReadRepository;

        public UpdateAppointmentCommandHandler(IEmployeeReadRepository employeeReadRepository,
            IClinicReadRepository clinicReadRepository,
            IPatientReadRepository patientReadRepository,
            IDiseaseReadRepository diseaseReadRepository,
            IAppointmentReadRepository appointmentReadRepository,
            IAppointmentWriteRepository appointmentWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _clinicReadRepository = clinicReadRepository;
            _patientReadRepository = patientReadRepository;
            _diseaseReadRepository = diseaseReadRepository;
            _appointmentReadRepository = appointmentReadRepository;
            _appointmentWriteRepository = appointmentWriteRepository;
        }

        public async Task<UpdateAppointmentCommandResponse> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
          var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if (patient == null) 
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

           var employee = await _employeeReadRepository.GetAll().Where(c => c.Id == request.EmployeeId).FirstOrDefaultAsync();
            if (employee == null) 
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotFind);
            }

            var disease = await _diseaseReadRepository.GetAll().Where(d => d.Id == request.DiseaseId).FirstOrDefaultAsync();
            if(disease == null)
            {
                throw new Exception(BussinessConstants.DiseaseCouldNotFind);
            }

            var appointment = await _appointmentReadRepository.GetAll().Where(a => a.Id == request.AppointmentId).FirstOrDefaultAsync();
            if (appointment == null) 
            {
                throw new Exception(BussinessConstants.AppointmentCouldNotFind);
            }

            appointment.AppointmentDate = request.AppointmentDate;
            appointment.PatientId = request.PatientId;
            appointment.ClinicId = request.ClinicId;
            appointment.Description = request.Description;
            appointment.EmployeeId = request.EmployeeId;
            appointment.DiseaseId = request.DiseaseId;

            _appointmentWriteRepository.Update(appointment);

            await _appointmentWriteRepository.SaveAsync();
            return new()
            {
                Message = BussinessConstants.AppointmentSuccessfullyUpdated,
                Succeeded = true,
            };
            
        }
    }
}
