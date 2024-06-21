using BeautyExpress.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BeautyExpress.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        #region MÉTODOS PÚBLICOS
        public EstabelecimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoEstabelecimento>>> GetEstabelecimento()
        {
            return await _context.Estabelecimento.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoEstabelecimento>> GetEstabelecimento(int id)
        {
            var estabelecimento = await _context.Estabelecimento.FindAsync(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }

            return estabelecimento;
        }

        [HttpPost]
        public async Task<ActionResult<DtoEstabelecimento>> PostEstabelecimento(DtoEstabelecimento estabelecimento)
        {
            _context.Estabelecimento.Add(estabelecimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstabelecimento), new { id = estabelecimento.Id }, estabelecimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstabelecimento(int id, DtoEstabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(estabelecimento).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstabelecimentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstabelecimento(int id)
        {
            var estabelecimento = await _context.Estabelecimento.FindAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            _context.Estabelecimento.Remove(estabelecimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region MÉTODOS PRIVADOS
        private bool EstabelecimentoExists(int id)
        {
            return _context.Estabelecimento.Any(e => e.Id == id);
        }
        #endregion
    }
}
