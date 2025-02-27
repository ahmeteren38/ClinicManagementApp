using ClinicManagement.Application.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Abstractions.Services
{
    public interface IAppointmentService
    {
        Task<bool> AddAppointment(AddAppointmentRequestDTO addAppointmentRequestDTO);
        Task<bool> DeleteAppointment(int appointmentId);
        Task<bool> UpdateAppointment(UpdateAppointmentRequestDTO updateAppointmentRequestDTO);
        Task<List<GetAllAppointmentResponseDTO>> GetAllAppointments();
        Task<GetAppointmentByIdResponseDTO> GetAppointmentById(int appointmentId);

            


    }
}
