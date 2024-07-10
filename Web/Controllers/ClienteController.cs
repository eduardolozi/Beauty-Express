using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Cliente;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> _repostorio;
        public ClienteController(IRepository<Cliente> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("clientes")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var clientes = await _repostorio.ObterTodos();
            return Ok(clientes);
        }

        [HttpGet("cliente/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var cliente = await _repostorio.ObterPorId(id);
            return Ok(cliente);
        }

        [HttpPost("cliente")]
        public async Task<CreatedResult> Adicionar([FromBody] Cliente cliente)
        {
            await _repostorio.Adicionar(cliente);
            return Created();
        }

        [HttpPatch("cliente/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Cliente cliente)
        {
            await _repostorio.Atualizar(id, cliente);
            return NoContent();
        }

        [HttpDelete("cliente/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}
