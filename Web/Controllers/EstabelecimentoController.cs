using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IRepository<Estabelecimento> _repostorio;
        public EstabelecimentoController(IRepository<Estabelecimento> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("estabelecimentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var estabelecimentos = await _repostorio.ObterTodos();
            return Ok(estabelecimentos);
        }

        [HttpGet("estabelecimento/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var estabelecimento = await _repostorio.ObterPorId(id);
            return Ok(estabelecimento);
        }

        [HttpPost("estabelecimento")]
        public async Task<CreatedResult> Adicionar([FromBody] Estabelecimento estabelecimento)
        {
            await _repostorio.Adicionar(estabelecimento);
            return Created();
        }

        [HttpPatch("estabelecimento/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Estabelecimento estabelecimento)
        {
            await _repostorio.Atualizar(id, estabelecimento);
            return NoContent();
        }

        [HttpDelete("estabelecimento/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}
