using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Controllers {
    [ApiController]
    [Route("cirquits")]
    public class CirquitController : ControllerBase {
        [HttpGet]
        public Task<ActionResult<IEnumerable<ICirquitDto>>> GetAllCirquits () {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<ActionResult<ICirquitDto>> GetCirquit(
            [FromRoute][Required] Guid Id
        ) {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult<ICirquitDto>> CreateCirquit(
            [FromBody][Required] ICirquitDto cirquitDto
        ) {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{Id}")]
        public Task<ActionResult<ICirquitDto>> UpdateCirquit(
            [FromRoute][Required] Guid Id,
            [FromBody][Required] ICirquitDto cirquitDto
        ) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<ActionResult> CreateCirquit(
            [FromRoute][Required] Guid Id
        ) {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{Id}/execute")]
        public Task<ActionResult<ICirquitResultDto>> ExecuteCirquit(
            [FromRoute][Required] Guid Id
        ) {
            throw new NotImplementedException();
        }
    }
}