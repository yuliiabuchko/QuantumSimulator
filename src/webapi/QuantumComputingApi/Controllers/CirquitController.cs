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
    [Route("/cirquits")]
    public class CirquitController : ControllerBase {

        private readonly ICirquitService _cirquitService;

        public CirquitController(ICirquitService service) {
            _cirquitService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>>> GetAllCirquits () {
            var result = await _cirquitService.GetAllCirquitsHandler();

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet]
        [Route("/{Uuid}")]
        public async Task<ActionResult<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetCirquit(
            [FromRoute][Required] Guid Uuid
        ) {
            var result = await _cirquitService.GetCirquitHandler(Uuid);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPost]
        public async Task<ActionResult> CreateCirquit(
            [FromBody][Required] ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto
        ) {
            await _cirquitService.CreateCirquitHandler(cirquitDto);

            return Ok();
        }

        [HttpPut]
        [Route("/{Uuid}")]
        public async Task<ActionResult> UpdateCirquit(
            [FromRoute][Required] Guid Uuid,
            [FromBody][Required] ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto
        ) {
            await _cirquitService.UpdateCirquitHandler(Uuid, cirquitDto);

            return Ok();
        }

        [HttpDelete]
        [Route("/{Uuid}")]
        public async Task<ActionResult> DeleteCirquit(
            [FromRoute][Required] Guid Uuid
        ) {
            await _cirquitService.DeleteCirquitHandler(Uuid);

            return Ok();
        }

        [HttpGet]
        [Route("/{Uuid}/execute")]
        public async Task<ActionResult<ICirquitResultDto>> ExecuteCirquit(
            [FromRoute][Required] Guid Uuid
        ) {
            var result = await _cirquitService.ExecuteCirquitHandler(Uuid);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }
    }
}