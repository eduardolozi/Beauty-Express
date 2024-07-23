using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation.Results;

namespace Dominio.Service;

public class ServicosService : BaseService, IServicosService
{
    private readonly IServicosRepository _servicosRepository;
    private readonly ServicosValidator _servicosValidator;

    public ServicosService(IServicosRepository servicosRepository, ServicosValidator servicosValidator)
    {
        _servicosRepository = servicosRepository;
        _servicosValidator = servicosValidator;
    }

    public async Task<Servico> Adicionar(Servico servico)
    {
        ValidationResult result = _servicosValidator.Validate(servico);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _servicosRepository.Adicionar(servico);
        return servico;
    }

    public async Task<bool> Atualizar(Servico servico)
    {
        ValidationResult result = _servicosValidator.Validate(servico);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _servicosRepository.ObterPorId(servico.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Cliente não encontrada!");
        }
        await _servicosRepository.Atualizar(servico.Id, servico);
        return true;
    }

    public async Task<Servico> ObterPorId(int id)
    {
        var servico = await _servicosRepository.ObterPorId(id);
        if (servico == null)
        {
            throw new Exception("Serviço não encontrada!");
        }
        return servico;
    }

    public async Task<IEnumerable<Servico>> ObterTodos()
    {
        return await _servicosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _servicosRepository.ObterPorId(id) == null)
        {
            throw new Exception(" não existe!");
        }

        await _servicosRepository.Remover(id);
        return true;
    }
}