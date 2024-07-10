using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Pagamento;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IRepository<Pagamento> _repostorio;
        public PagamentoController(IRepository<Pagamento> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("pagamentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var pagamentos = await _repostorio.ObterTodos();
            return Ok(pagamentos);
        }

        [HttpGet("pagamento/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var pagamento = await _repostorio.ObterPorId(id);
            return Ok(pagamento);
        }

        [HttpPost("pagamento")]
        public async Task<CreatedResult> Adicionar([FromBody] Pagamento pagamento)
        {
            await _repostorio.Adicionar(pagamento);
            return Created();
        }

        [HttpPatch("pagamento/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Pagamento pagamento)
        {
            await _repostorio.Atualizar(id, pagamento);
            return NoContent();
        }

        [HttpDelete("pagamento/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}
