using Dominio.Interfaces;
using Dominio.Service;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;
using Modelos.PagamentoCartao;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoCartaoController : ControllerBase
    {
        private IPagamentoCartaoService _pagamentoCartaoService;

        public PagamentoCartaoController(IPagamentoCartaoService pagamentoCartaoService)
        {
            _pagamentoCartaoService = pagamentoCartaoService;
        }

        [HttpGet("pagamentosCartao")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _pagamentoCartaoService.ObterTodos());
        }

        [HttpGet("pagamentoCartao/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _pagamentoCartaoService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("pagamentoCartao")]
        public async Task<ActionResult> Adicionar([FromBody] PagamentoCartao pagamentoCartao)
        {
            try
            {
                return Ok(await _pagamentoCartaoService.Adicionar(pagamentoCartao));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("pagamentoCartao/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] PagamentoCartao pagamentoCartao)
        {
            if (id == 0 || id != pagamentoCartao.Id)
            {
                return NotFound();
            }

            try
            {
                await _pagamentoCartaoService.Atualizar(pagamentoCartao);
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

        [HttpDelete("pagamentoCartao/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _pagamentoCartaoService.Remover(id));
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

