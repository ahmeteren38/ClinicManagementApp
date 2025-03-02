using ClinicManagement.Application.DTOs.Appointment;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Application.Features.Query.Appointment.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQueryRequest, GetAllAppointmentsQueryResponse>
    {
        readonly IAppointmentReadRepository _appointmentReadRepository;

        public GetAllAppointmentsQueryHandler(IAppointmentReadRepository appointmentReadRepository)
        {
            _appointmentReadRepository = appointmentReadRepository;
        }

        public async Task<GetAllAppointmentsQueryResponse> Handle(GetAllAppointmentsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllAppointmentsResponseDTO> appointmentList = new List<GetAllAppointmentsResponseDTO>();

            var appointments = await _appointmentReadRepository.GetAll().ToListAsync();

            foreach (var appointment in appointments)
            {
                GetAllAppointmentsResponseDTO getAllAppointments = new GetAllAppointmentsResponseDTO();

                getAllAppointments.AppointmentDate = appointment.AppointmentDate;
                getAllAppointments.PatientId = appointment.PatientId;
                getAllAppointments.ClinicId = appointment.ClinicId;
                getAllAppointments.EmployeeId = appointment.EmployeeId;
                getAllAppointments.Description = appointment.Description;
                getAllAppointments.DiseaseId = appointment.DiseaseId;
                

                appointmentList.Add(getAllAppointments);
            }

            return new GetAllAppointmentsQueryResponse
            {
                Succeeded = true,
                Appointments = appointmentList
            };
        }
    }
}
