using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modelos.DataHorario;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataHorarioController : ControllerBase
    {
        private readonly IRepository<DataHorario> _repostorio;
        public DataHorarioController(IRepository<DataHorario> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("dataHorarios")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var dataHorarios = await _repostorio.ObterTodos();
            return Ok(dataHorarios);
        }

        [HttpGet("dataHorarios/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var dataHorario = await _repostorio.ObterPorId(id);
            return Ok(dataHorario);
        }

        [HttpPost("dataHorario")]
        public async Task<CreatedResult> Adicionar([FromBody] DataHorario dataHorario)
        {
            await _repostorio.Adicionar(dataHorario);
            return Created();
        }

        [HttpPatch("pagamento/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] DataHorario dataHorario)
        {
            await _repostorio.Atualizar(id, dataHorario);
            return NoContent();
        }

        [HttpDelete("dataHorario/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}
