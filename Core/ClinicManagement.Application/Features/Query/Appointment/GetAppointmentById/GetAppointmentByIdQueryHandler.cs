using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Appointment.GetAppointmentById
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQueryRequest, GetAppointmentByIdQueryResponse>
    {
        readonly IAppointmentReadRepository _appointmentReadRepository;

        public GetAppointmentByIdQueryHandler(IAppointmentReadRepository appointmentReadRepository)
        {
            _appointmentReadRepository = appointmentReadRepository;
        }

        public async Task<GetAppointmentByIdQueryResponse> Handle(GetAppointmentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentReadRepository.GetAll().Where(a => a.Id == request.AppointmentId).FirstOrDefaultAsync();

            if (appointment == null) 
            {
                return new GetAppointmentByIdQueryResponse
                {
                    Succeeded = false,
                    Message = BussinessConstants.AppointmentCouldNotFind
                };
            }

            return new GetAppointmentByIdQueryResponse
            {
                AppointmentDate = appointment.AppointmentDate,
                ClinicId = appointment.ClinicId,
                Description = appointment.Description,
                DiseaseId = appointment.DiseaseId,
                PatientId = appointment.PatientId,
                EmployeeId = appointment.EmployeeId,
            };
        }
    }
}
