using ClinicManagement.Application.Features.Command.Disease.AddDisease;
using ClinicManagement.Application.Features.Command.Disease.DeleteDisease;
using ClinicManagement.Application.Features.Command.Disease.UpdateDisease;
using ClinicManagement.Application.Features.Query.Disease.GetAllDiseases;
using ClinicManagement.Application.Features.Query.Disease.GetDiseaseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        readonly IMediator _mediator;

        public DiseasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddDisease([FromBody] AddDiseaseCommandRequest addDiseaseCommandRequest)
        {
          AddDiseaseCommandResponse response = await _mediator.Send(addDiseaseCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDisease(DeleteDiseaseCommandRequest deleteDiseaseCommandRequest)
        {
           DeleteDiseaseCommandResponse response = await _mediator.Send(deleteDiseaseCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDisease(UpdateDiseaseCommandRequest updateDiseaseCommandRequest)
        {
          UpdateDiseaseCommandResponse response = await _mediator.Send(updateDiseaseCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDiseases()
        {
            var result = await _mediator.Send(new GetAllDiseasesQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDiseaseById([FromQuery] GetDiseaseByIdQueryRequest getDiseaseByIdQueryRequest)
        {
           GetDiseaseByIdQueryResponse response = await _mediator.Send(getDiseaseByIdQueryRequest);
            return Ok(response);
        }
    }
}
