using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;            
        }

        [HttpGet("clientes")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _clienteService.ObterTodos());
        }

        [HttpGet("cliente/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _clienteService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("cliente")]
        public async Task<ActionResult> Adicionar([FromBody] Cliente cliente)
        {
            try
            {
                return Ok(await _clienteService.Adicionar(cliente));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("cliente/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Cliente cliente)
        {
            if (id == 0 || id != cliente.Id)
            {
                return NotFound();
            }

            try
            {
                await _clienteService.Atualizar(cliente);
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

        [HttpDelete("cliente/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _clienteService.Remover(id));
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
