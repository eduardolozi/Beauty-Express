using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentosService _estabelecimentosService;
        public EstabelecimentoController(IEstabelecimentosService estabelecimentosService)
        {
            _estabelecimentosService = estabelecimentosService;
        }

        [HttpGet("estabelecimentos")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _estabelecimentosService.ObterTodos());
        }

        [HttpGet("estabelecimento/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _estabelecimentosService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("estabelecimento")]
        public async Task<ActionResult> Adicionar([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                return Ok(await _estabelecimentosService.Adicionar(estabelecimento));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("estabelecimento/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Estabelecimento estabelecimento)
        {
            if (id == 0 || id != estabelecimento.Id)
            {
                return NotFound();
            }

            try
            {
                await _estabelecimentosService.Atualizar(estabelecimento);
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

        [HttpDelete("estabelecimento/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _estabelecimentosService.Remover(id));
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
