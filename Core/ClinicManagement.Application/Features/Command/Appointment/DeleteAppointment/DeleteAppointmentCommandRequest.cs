﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Appointment.DeleteAppointment
{
    public class DeleteAppointmentCommandRequest : IRequest<DeleteAppointmentCommandResponse>
    {
        public int AppointmentId { get; set; }
    }
}
