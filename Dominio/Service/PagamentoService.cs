using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.Pagamento;

namespace Dominio.Service;

public class PagamentoService : BaseService, IPagamentoService
{
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly PagamentoValidator _pagamentosValidator;

    public PagamentoService(IPagamentoRepository pagamentoRepository, PagamentoValidator pagamentosValidator)
    {
        _pagamentoRepository = pagamentoRepository;
        _pagamentosValidator = pagamentosValidator;
    }

    public async Task<Pagamento> Adicionar(Pagamento pagamento)
    {
        ValidationResult result = _pagamentosValidator.Validate(pagamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _pagamentoRepository.Adicionar(pagamento);
        return pagamento;
    }

    public async Task<bool> Atualizar(Pagamento pagamento)
    {
        ValidationResult result = _pagamentosValidator.Validate(pagamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _pagamentoRepository.ObterPorId(pagamento.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Pagamento não encontrada!");
        }
        await _pagamentoRepository.Atualizar(pagamento.Id, pagamento);
        return true;
    }

    public async Task<Pagamento> ObterPorId(int id)
    {
        var pagamento = await _pagamentoRepository.ObterPorId(id);
        if (pagamento == null)
        {
            throw new Exception("Pagamento não encontrada!");
        }
        return pagamento;
    }

    public async Task<IEnumerable<Pagamento>> ObterTodos()
    {
        return await _pagamentoRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _pagamentoRepository.ObterPorId(id) == null)
        {
            throw new Exception("Pagamento não existe!");
        }

        await _pagamentoRepository.Remover(id);
        return true;
    }
}