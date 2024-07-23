using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation.Results;

namespace Dominio.Service;

public class AgendamentosService : BaseService, IAgendamentosService
{
    private readonly IAgendamentosRepository _agendamentosRepository;
    private readonly AgendamentosValidator _agendamentosValidator;

    public AgendamentosService(IAgendamentosRepository agendamentosRepository, AgendamentosValidator agendamentosValidator)
    {
        _agendamentosRepository = agendamentosRepository;
        _agendamentosValidator = agendamentosValidator;
    }

    public async Task<Agendamento> Adicionar(Agendamento agendamento)
    {
        ValidationResult result = _agendamentosValidator.Validate(agendamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _agendamentosRepository.Adicionar(agendamento);
        return agendamento;
    }

    public async Task<bool> Atualizar(Agendamento agendamento)
    {
        ValidationResult result = _agendamentosValidator.Validate(agendamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _agendamentosRepository.ObterPorId(agendamento.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Agendamento não encontrada!");
        }
        await _agendamentosRepository.Atualizar(agendamento.Id, agendamento);
        return true;
    }

    public async Task<Agendamento> ObterPorId(int id)
    {
        var agendamento = await _agendamentosRepository.ObterPorId(id);
        if (agendamento == null)
        {
            throw new Exception("Agendamento não encontrada!");
        }
        return agendamento;
    }

    public async Task<IEnumerable<Agendamento>> ObterTodos()
    {
        return await _agendamentosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _agendamentosRepository.ObterPorId(id) == null)
        {
            throw new Exception("Agendamento não existe!");
        }

        await _agendamentosRepository.Remover(id);
        return true;
    }
}