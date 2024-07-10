using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Modelos.Pagamento;
using Modelos.PagamentoCartao;

namespace Infra.Repositorios
{
    public class PagamentoCartaoRepository : IRepository<PagamentoCartao>
    {
        private readonly BeautyContext _contexto;
        private readonly PagamentoCartaoValidator _validator;
        public PagamentoCartaoRepository(BeautyContext contexto, PagamentoCartaoValidator validator)
        {
            _contexto = contexto;
            _validator = validator;
        }

        public async Task<List<PagamentoCartao>> ObterTodos()
        {
            return await _contexto.PagamentosCartao.ToListAsync();
        }
        public async Task<PagamentoCartao> ObterPorId(int id)
        {
            return await _contexto.PagamentosCartao.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(PagamentoCartao pagamentoCartao)
        {
            var result = _validator.Validate(pagamentoCartao);
            if (!result.IsValid)
            {
                var mensagem = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(mensagem);
            }
            await _contexto.AddAsync(pagamentoCartao);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var pagamentoCartao = await ObterPorId(id);
            _contexto.Remove(pagamentoCartao);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, PagamentoCartao pagamentoCartao)
        {
            var result = _validator.Validate(pagamentoCartao);
            if (!result.IsValid)
            {
                var mensagem = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(mensagem);
            }
            var pagamentoCartaoNoBanco = await ObterPorId(id);
            _contexto.Attach(pagamentoCartaoNoBanco).CurrentValues.SetValues(pagamentoCartao);
            await _contexto.SaveChangesAsync();
        }
    }
}