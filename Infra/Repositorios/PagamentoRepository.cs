using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Modelos.Pagamento;

namespace Infra.Repositorios
{
    public class PagamentoRepository : IRepository<Pagamento>
    {
        private readonly BeautyContext _contexto;
        private readonly PagamentoValidator _validator;
        public PagamentoRepository(BeautyContext contexto, PagamentoValidator validator)
        {
            _contexto = contexto;
            _validator = validator;
        }

        public async Task<List<Pagamento>> ObterTodos()
        {
            return await _contexto.Pagamentos.ToListAsync();
        }
        public async Task<Pagamento> ObterPorId(int id)
        {
            return await _contexto.Pagamentos.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Pagamento pagamento)
        {
            var result = _validator.Validate(pagamento);
            if (!result.IsValid)
            {
                var mensagem = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(mensagem);
            } 
            await _contexto.AddAsync(pagamento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var pagamento = await ObterPorId(id);
            _contexto.Remove(pagamento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Pagamento pagamento)
        {
            var result = _validator.Validate(pagamento);
            if (!result.IsValid)
            {
                var mensagem = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(mensagem);
            }
            var pagamentoNoBanco = await ObterPorId(id);
            _contexto.Attach(pagamentoNoBanco).CurrentValues.SetValues(pagamento);
            await _contexto.SaveChangesAsync();
        }
    }
}