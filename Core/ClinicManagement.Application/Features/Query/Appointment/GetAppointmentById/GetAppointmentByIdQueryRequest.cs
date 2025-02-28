using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Appointment.GetAppointmentById
{
    public class GetAppointmentByIdQueryRequest : IRequest<GetAppointmentByIdQueryResponse>
    {
        public int AppointmentId { get; set; }
    }
}
