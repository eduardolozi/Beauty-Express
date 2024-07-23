using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentosService _agendamentosService;

        public AgendamentoController(IAgendamentosService agendamentosService)
        {
            _agendamentosService = agendamentosService;
        }

        [HttpGet("agendamentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _agendamentosService.ObterTodos());
        }

        [HttpGet("agendamento/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _agendamentosService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("agendamento")]
        public async Task<ActionResult> Adicionar([FromBody] Agendamento agendamento)
        {
            try
            {
                return Ok(await _agendamentosService.Adicionar(agendamento));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("agendamento/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Agendamento agendamento)
        {
            if (id == 0 || id != agendamento.Id)
            {
                return NotFound();
            }

            try
            {
                await _agendamentosService.Atualizar(agendamento);
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

        [HttpDelete("agendamento/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _agendamentosService.Remover(id));
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
