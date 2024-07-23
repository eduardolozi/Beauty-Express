using Dominio.Interfaces;
using Dominio.Service;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;
using Modelos.DataHorario;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataHorarioController : ControllerBase
    {
        private readonly IDataHorariosService _dataHorariosService;

        public DataHorarioController(IDataHorariosService dataHorariosService)
        {
            _dataHorariosService = dataHorariosService;
        }

        [HttpGet("dataHorarios")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _dataHorariosService.ObterTodos());
        }

        [HttpGet("dataHorarios/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _dataHorariosService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("dataHorario")]
        public async Task<ActionResult> Adicionar([FromBody] DataHorario dataHorario)
        {
            try
            {
                return Ok(await _dataHorariosService.Adicionar(dataHorario));
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
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] DataHorario dataHorario)
        {
            if (id == 0 || id != dataHorario.Id)
            {
                return NotFound();
            }

            try
            {
                await _dataHorariosService.Atualizar(dataHorario);
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

        [HttpDelete("dataHorario/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _dataHorariosService.Remover(id));
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
