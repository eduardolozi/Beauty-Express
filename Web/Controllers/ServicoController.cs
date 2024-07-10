using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IRepository<Servico> _repostorio;
        public ServicoController(IRepository<Servico> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("servicos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var servicos = await _repostorio.ObterTodos();
            return Ok(servicos);
        }

        [HttpGet("servico/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var servico = await _repostorio.ObterPorId(id);
            return Ok(servico);
        }

        [HttpPost("servico")]
        public async Task<CreatedResult> Adicionar([FromBody] Servico servico)
        {
            await _repostorio.Adicionar(servico);
            return Created();
        }

        [HttpPatch("servico/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Servico servico)
        {
            await _repostorio.Atualizar(id, servico);
            return NoContent();
        }

        [HttpDelete("servico/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}