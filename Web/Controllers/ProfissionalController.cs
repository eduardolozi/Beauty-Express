using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Profissional;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IRepository<Profissional> _repostorio;
        public ProfissionalController(IRepository<Profissional> repostorio)
        {
            _repostorio = repostorio;
        }

        [HttpGet("profissionais")]
        public async Task<OkObjectResult> ObterTodos()
        {
            var profissionais = await _repostorio.ObterTodos();
            return Ok(profissionais);
        }

        [HttpGet("profissional/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            var profissional = await _repostorio.ObterPorId(id);
            return Ok(profissional);
        }

        [HttpPost("profissional")]
        public async Task<CreatedResult> Adicionar([FromBody] Profissional profissional)
        {
            await _repostorio.Adicionar(profissional);
            return Created();
        }

        [HttpPatch("profssional/{id}")]
        public async Task<NoContentResult> Atualizar([FromRoute] int id, [FromBody] Profissional profissional)
        {
            await _repostorio.Atualizar(id, profissional);
            return NoContent();
        }

        [HttpDelete("profissional/{id}")]
        public async Task<NoContentResult> Remover([FromRoute] int id)
        {
            await _repostorio.Remover(id);
            return NoContent();
        }
    }
}