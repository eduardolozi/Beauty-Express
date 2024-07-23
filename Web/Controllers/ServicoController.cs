using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private IServicosService _servicosService;

        public ServicoController(IServicosService servicosService)
        {
            _servicosService = servicosService;
        }

        [HttpGet("servicos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _servicosService.ObterTodos());
        }

        [HttpGet("servico/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _servicosService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("servico")]
        public async Task<ActionResult> Adicionar([FromBody] Servico servico)
        {
            try
            {
                return Ok(await _servicosService.Adicionar(servico));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("servico/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Servico servico)
        {
            if (id == 0 || id != servico.Id)
            {
                return NotFound();
            }

            try
            {
                await _servicosService.Atualizar(servico);
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }

            return NoContent();
        }

        [HttpDelete("servico/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _servicosService.Remover(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
            return NoContent();
        }
    }
}