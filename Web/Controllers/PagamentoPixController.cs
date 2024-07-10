using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.PagamentoPix;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoPixController : ControllerBase
    {
        private readonly IRepository<PagamentoPix> _repostorio;
        public PagamentoPixController(IRepository<PagamentoPix> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("pagamentosPix")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var pagamentosPix = await _repostorio.ObterTodos();
            return Ok(pagamentosPix);
        }

        [HttpGet("pagamentoPix/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var pagamentoPix = await _repostorio.ObterPorId(id);
            return Ok(pagamentoPix);
        }

        [HttpPost("pagamentoPix")]
        public async Task<CreatedResult> Adicionar([FromBody] PagamentoPix pagamentoPix)
        {
            await _repostorio.Adicionar(pagamentoPix);
            return Created();
        }

        [HttpPatch("pagamentoPix/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] PagamentoPix pagamentoPix)
        {
            await _repostorio.Atualizar(id, pagamentoPix);
            return NoContent();
        }

        [HttpDelete("pagamentoPix/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}

