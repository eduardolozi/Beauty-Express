using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;
using Modelos.Pagamento;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpGet("pagamentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _pagamentoService.ObterTodos());
        }

        [HttpGet("pagamento/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _pagamentoService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("pagamento")]
        public async Task<ActionResult> Adicionar([FromBody] Pagamento pagamento)
        {
            try
            {
                return Ok(await _pagamentoService.Adicionar(pagamento));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("pagamento/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Pagamento pagamento)
        {
            if (id == 0 || id != pagamento.Id)
            {
                return NotFound();
            }

            try
            {
                await _pagamentoService.Atualizar(pagamento);
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

        [HttpDelete("pagamento/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _pagamentoService.Remover(id));
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
