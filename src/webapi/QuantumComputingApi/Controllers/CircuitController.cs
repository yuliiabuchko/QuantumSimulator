using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Services;
using System.Net;

namespace QuantumComputingApi.Controllers {
    [ApiController]
    [Route("/circuit")]
    public class CircuitController : ControllerBase {

        private readonly ICircuitService _circuitService;

        public CircuitController(ICircuitService service) {
            _circuitService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICircuitDto>>>  GetAllCircuits () {
            var result = await _circuitService.GetAllCircuitsHandler();

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet]
        [Route("{Uuid}")]
        public async Task<ActionResult<ICircuitDto>> GetCircuit(
            [FromRoute][Required] Guid Uuid
        ) {
            var result = await _circuitService.GetCircuitHandler(Uuid);

            if(result == null) {
                return NotFound("Could not find specified resource");
            }else{
                return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCircuit(
            [FromBody][Required] ICircuitDto circuitDto
        ) {
            var created = await _circuitService.CreateCircuitHandler(circuitDto);

            if( created == null ){
                return Conflict("Error while creating resource");
            }else{
                return Created($"/circuit/{created.ToString()}", created);
            }
        }

        [HttpPut]
        [Route("{Uuid}")]
        public async Task<ActionResult> UpdateCircuit(
            [FromRoute][Required] Guid Uuid,
            [FromBody][Required] ICircuitDto circuitDto
        ) {
            await _circuitService.UpdateCircuitHandler(Uuid, circuitDto);

            return Ok();
        }

        [HttpDelete]
        [Route("{Uuid}")]
        public async Task<ActionResult> DeleteCircuit(
            [FromRoute][Required] Guid Uuid
        ) {
            await _circuitService.DeleteCircuitHandler(Uuid);

            return Ok();
        }

        [HttpGet]
        [Route("{Uuid}/execute")]
        public async Task<ActionResult<ICircuitResultDto>> ExecuteCircuit(
            [FromRoute][Required] Guid Uuid
        ) {
            var result = await _circuitService.ExecuteCircuitHandler(Uuid);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }
    }
}