using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Appointment.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, DeleteAppointmentCommandResponse>
    {
       readonly IAppointmentReadRepository _appointmentReadRepository;
       readonly IAppointmentWriteRepository _appointmentWriteRepository;

        public DeleteAppointmentCommandHandler(IAppointmentReadRepository appointmentReadRepository, IAppointmentWriteRepository appointmentWriteRepository)
        {
            _appointmentReadRepository = appointmentReadRepository;
            _appointmentWriteRepository = appointmentWriteRepository;
        }

        public async Task<DeleteAppointmentCommandResponse> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
          var appointment = await _appointmentReadRepository.GetAll().Where(a => a.Id == request.AppointmentId).FirstOrDefaultAsync();
            if (appointment == null) 
            {
                throw new Exception(BussinessConstants.AppointmentCouldNotDelete);
            }

            _appointmentWriteRepository.Remove(appointment);

           await _appointmentWriteRepository.SaveAsync();
            return new()
            {
                Message = BussinessConstants.AppointmentSuccessfullyDeleted,
                Succeeded = true,
            };
        }
    }
}
