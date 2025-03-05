using ClinicManagement.Application.Features.Command.Employee.AddEmloyee;
using ClinicManagement.Application.Features.Command.Employee.DeleteEmployee;
using ClinicManagement.Application.Features.Command.Employee.UpdateEmployee;
using ClinicManagement.Application.Features.Query.Employee.GetAllEmployees;
using ClinicManagement.Application.Features.Query.Employee.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommandRequest addEmployeeCommandRequest)
        {
           AddEmployeeCommandResponse response = await _mediator.Send(addEmployeeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeCommandRequest deleteEmployeeCommandRequest)
        {
          DeleteEmployeeCommandResponse response = await _mediator.Send(deleteEmployeeCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
        {
           UpdateEmployeeCommandResponse response = await _mediator.Send(updateEmployeeCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] GetEmployeeByIdQueryRequest getEmployeeByIdQueryRequest)
        {
            GetEmployeeByIdQueryResponse response = await _mediator.Send(getEmployeeByIdQueryRequest);
            return Ok(response);

        }
    }
}
