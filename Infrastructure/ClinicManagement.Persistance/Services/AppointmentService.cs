using ClinicManagement.Application.Abstractions.Services;
using ClinicManagement.Application.DTOs.Appointment;
using ClinicManagement.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistance.Services
{
    public class AppointmentService : IAppointmentService
    {
        readonly IAppointmentReadRepository _appointmentReadRepository;
        readonly IAppointmentWriteRepository _appointmentWriteRepository;
        readonly IPatientReadRepository _petientReadRepository;

        public AppointmentService(IAppointmentWriteRepository appointmentWriteRepository,
            IPatientReadRepository petientReadRepository,
            IAppointmentReadRepository appointmentReadRepository)
        {
            _appointmentWriteRepository = appointmentWriteRepository;
            _petientReadRepository = petientReadRepository;
            _appointmentReadRepository = appointmentReadRepository;
        }

        public async Task<bool> AddAppointment(AddAppointmentRequestDTO addAppointmentRequestDTO)
        {
            var patient = await _petientReadRepository.GetAll().Where(p => p.Id.Equals(addAppointmentRequestDTO.PatientId)).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new Exception("The patient could not find.");
            }

            var result = await _appointmentWriteRepository.AddAsync(new()
            {
                AppointmentDate = addAppointmentRequestDTO.AppointmentDate,
            });

            if(result == null)
            {
                throw new Exception("Appointment could not add");
            }

           await _appointmentWriteRepository.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteAppointment(int appointmentId)
        {
          var appointment = await _appointmentReadRepository.GetAll().Where(a => a.Id == appointmentId).FirstOrDefaultAsync();
            if(appointment == null)
            {
                throw new Exception("Appointment could not deleted");
            }

            appointment.AppointmentDeletedDate = DateTime.Now;

             _appointmentWriteRepository.Update(appointment);

            await _appointmentWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<GetAllAppointmentResponseDTO>> GetAllAppointments()
        {
            List<GetAllAppointmentResponseDTO> appointmentList = new List<GetAllAppointmentResponseDTO>();
            var appointments = await _appointmentReadRepository.GetAll().ToListAsync();
            foreach (var appointment in appointments)
            {
                GetAllAppointmentResponseDTO getAllAppointmentResponseDTO = new GetAllAppointmentResponseDTO();

                getAllAppointmentResponseDTO.Id = appointment.Id;
                getAllAppointmentResponseDTO.AppointmentDate = appointment.AppointmentDate;
                
                appointmentList.Add(getAllAppointmentResponseDTO);
            }
            return appointmentList;
        }

        public async Task<GetAppointmentByIdResponseDTO> GetAppointmentById(int appointmentId)
        {
            GetAppointmentByIdResponseDTO getAppointmentByIdResponseDTO = new GetAppointmentByIdResponseDTO();

            var appointment = await _appointmentReadRepository.GetAll().Where(a => a.Id == appointmentId).FirstOrDefaultAsync();

            if (appointment == null) 
            {
                throw new Exception("Appointment could not find");
            }

            getAppointmentByIdResponseDTO.Id = appointment.Id;
            getAppointmentByIdResponseDTO.AppointmentDate = appointment.AppointmentDate;

            return getAppointmentByIdResponseDTO;
        }

        public async Task<bool> UpdateAppointment(UpdateAppointmentRequestDTO updateAppointmentRequestDTO)
        {
            var appointment = await _appointmentReadRepository.GetAll().Where(u => u.Id == updateAppointmentRequestDTO.Id).FirstOrDefaultAsync();
            if (appointment == null)
            {
                throw new Exception("Appointment could not find");
            }

            appointment.AppointmentUpdatedDate = DateTime.Now;

            _appointmentWriteRepository.Update(appointment);

            await _appointmentWriteRepository.SaveAsync();
            
            return true;
        }
    }
}
