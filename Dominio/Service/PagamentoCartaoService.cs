using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.PagamentoCartao;

namespace Dominio.Service;

public class PagamentoCartaoService : BaseService, IPagamentoCartaoService
{
    private readonly IPagamentoCartaoRepository _pagamentoCartaoRepository;
    private readonly PagamentoCartaoValidator _pagamentoCartaoValidator;

    public PagamentoCartaoService(IPagamentoCartaoRepository pagamentoCartaoRepository, PagamentoCartaoValidator pagamentoCartaoValidator)
    {
        _pagamentoCartaoRepository = pagamentoCartaoRepository;
        _pagamentoCartaoValidator = pagamentoCartaoValidator;
    }

    public async Task<PagamentoCartao> Adicionar(PagamentoCartao pagamentoCartao)
    {
        ValidationResult result = _pagamentoCartaoValidator.Validate(pagamentoCartao);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _pagamentoCartaoRepository.Adicionar(pagamentoCartao);
        return pagamentoCartao;
    }

    public async Task<bool> Atualizar(PagamentoCartao pagamentoCartao)
    {
        ValidationResult result = _pagamentoCartaoValidator.Validate(pagamentoCartao);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _pagamentoCartaoRepository.ObterPorId(pagamentoCartao.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Pagamento Cartão não encontrada!");
        }
        await _pagamentoCartaoRepository.Atualizar(pagamentoCartao.Id, pagamentoCartao);
        return true;
    }

    public async Task<PagamentoCartao> ObterPorId(int id)
    {
        var pagamentoCartao = await _pagamentoCartaoRepository.ObterPorId(id);
        if (pagamentoCartao == null)
        {
            throw new Exception("Pagamento Cartão não encontrada!");
        }
        return pagamentoCartao;
    }

    public async Task<IEnumerable<PagamentoCartao>> ObterTodos()
    {
        return await _pagamentoCartaoRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _pagamentoCartaoRepository.ObterPorId(id) == null)
        {
            throw new Exception("Pagamento Cartão não existe!");
        }

        await _pagamentoCartaoRepository.Remover(id);
        return true;
    }
}