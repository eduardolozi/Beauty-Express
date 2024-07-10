using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IRepository<Agendamento> _repostorio;
        public AgendamentoController(IRepository<Agendamento> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("agendamentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var agendamentos = await _repostorio.ObterTodos();
            return Ok(agendamentos);
        }

        [HttpGet("agendamento/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var agendamento = await _repostorio.ObterPorId(id);
            return Ok(agendamento);
        }

        [HttpPost("agendamento")]
        public async Task<CreatedResult> Adicionar([FromBody] Agendamento agendamento)
        {
            await _repostorio.Adicionar(agendamento);
            return Created();
        }

        [HttpPatch("agendamento/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Agendamento agendamento)
        {
            await _repostorio.Atualizar(id, agendamento);
            return NoContent();
        }

        [HttpDelete("agendamento/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}
