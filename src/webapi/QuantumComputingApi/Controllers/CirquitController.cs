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
    [Route("cirquits")]
    public class CirquitController : ControllerBase {

        private readonly ICirquitService _cirquitService;

        public CirquitController(ICirquitService service) {
            _cirquitService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICirquitDto>>> GetAllCirquits () {
            var result = await _cirquitService.GetAllCirquitsHandler();

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<ICirquitDto>> GetCirquit(
            [FromRoute][Required] Guid Id
        ) {
            var result = await _cirquitService.GetCirquitHandler(Id);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPost]
        public async Task<ActionResult<ICirquitDto>> CreateCirquit(
            [FromBody][Required] ICirquitDto cirquitDto
        ) {
            var result = await _cirquitService.CreateCirquitHandler(cirquitDto);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<ICirquitDto>> UpdateCirquit(
            [FromRoute][Required] Guid Id,
            [FromBody][Required] ICirquitDto cirquitDto
        ) {
            var result = await _cirquitService.UpdateCirquitHandler(Id, cirquitDto);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> DeleteCirquit(
            [FromRoute][Required] Guid Id
        ) {
            await _cirquitService.DeleteCirquitHandler(Id);

            return Ok();
        }

        [HttpGet]
        [Route("{Id}/execute")]
        public async Task<ActionResult<ICirquitResultDto>> ExecuteCirquit(
            [FromRoute][Required] Guid Id
        ) {
            var result = await _cirquitService.ExecuteCirquitHandler(Id);

            return new JsonResult(result){ StatusCode = (int)HttpStatusCode.OK };
        }
    }
}