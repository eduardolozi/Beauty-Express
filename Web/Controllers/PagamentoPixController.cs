using Dominio.Interfaces;
using Dominio.Service;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;
using Modelos.PagamentoPix;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoPixController : ControllerBase
    {
        private readonly IPagamentosPixService _pagamentosPixService;

        public PagamentoPixController(IPagamentosPixService pagamentosPixService)
        {
            _pagamentosPixService = pagamentosPixService;
        }

        [HttpGet("pagamentosPix")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _pagamentosPixService.ObterTodos());
        }

        [HttpGet("pagamentoPix/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _pagamentosPixService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("pagamentoPix")]
        public async Task<ActionResult> Adicionar([FromBody] PagamentoPix pagamentoPix)
        {
            try
            {
                return Ok(await _pagamentosPixService.Adicionar(pagamentoPix));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("pagamentoPix/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] PagamentoPix pagamentoPix)
        {
            if (id == 0 || id != pagamentoPix.Id)
            {
                return NotFound();
            }

            try
            {
                await _pagamentosPixService.Atualizar(pagamentoPix);
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

        [HttpDelete("pagamentoPix/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _pagamentosPixService.Remover(id));
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

