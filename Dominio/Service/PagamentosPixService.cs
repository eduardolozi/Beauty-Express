using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.PagamentoPix;

namespace Dominio.Service;

public class PagamentosPixService : BaseService, IPagamentosPixService
{
    private readonly IPagamentosPixRepository _pagamentosPixRepository;
    private readonly PagamentosPixValidator _pagamentosPixValidator;

    public PagamentosPixService(IPagamentosPixRepository pagamentosPixRepository, PagamentosPixValidator pagamentosPixValidator)
    {
        _pagamentosPixRepository = pagamentosPixRepository;
        _pagamentosPixValidator = pagamentosPixValidator;
    }

    public async Task<PagamentoPix> Adicionar(PagamentoPix pagamentoPix)
    {
        ValidationResult result = _pagamentosPixValidator.Validate(pagamentoPix);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _pagamentosPixRepository.Adicionar(pagamentoPix);
        return pagamentoPix;
    }

    public async Task<bool> Atualizar(PagamentoPix pagamentoPix)
    {
        ValidationResult result = _pagamentosPixValidator.Validate(pagamentoPix);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _pagamentosPixRepository.ObterPorId(pagamentoPix.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Pagamento Pix não encontrada!");
        }
        await _pagamentosPixRepository.Atualizar(pagamentoPix.Id, pagamentoPix);
        return true;
    }

    public async Task<PagamentoPix> ObterPorId(int id)
    {
        var pagamentoPix = await _pagamentosPixRepository.ObterPorId(id);
        if (pagamentoPix == null)
        {
            throw new Exception("Pagamento Pix não encontrada!");
        }
        return pagamentoPix;
    }

    public async Task<IEnumerable<PagamentoPix>> ObterTodos()
    {
        return await _pagamentosPixRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _pagamentosPixRepository.ObterPorId(id) == null)
        {
            throw new Exception("Pagamento Pix não existe!");
        }

        await _pagamentosPixRepository.Remover(id);
        return true;
    }
}