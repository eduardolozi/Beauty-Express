using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.PagamentoCartao;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoCartaoController : ControllerBase
    {
        private readonly IRepository<PagamentoCartao> _repostorio;
        public PagamentoCartaoController(IRepository<PagamentoCartao> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("pagamentosCartao")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var pagamentosCartao = await _repostorio.ObterTodos();
            return Ok(pagamentosCartao);
        }

        [HttpGet("pagamentoCartao/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var pagamentoCartao = await _repostorio.ObterPorId(id);
            return Ok(pagamentoCartao);
        }

        [HttpPost("pagamentoCartao")]
        public async Task<CreatedResult> Adicionar([FromBody] PagamentoCartao pagamentoCartao)
        {
            await _repostorio.Adicionar(pagamentoCartao);
            return Created();
        }

        [HttpPatch("pagamentoCartao/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] PagamentoCartao pagamentoCartao)
        {
            await _repostorio.Atualizar(id, pagamentoCartao);
            return NoContent();
        }

        [HttpDelete("pagamentoCartao/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}

