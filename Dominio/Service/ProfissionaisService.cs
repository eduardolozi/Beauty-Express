using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.Cliente;
using Modelos.Profissional;

namespace Dominio.Service;

public class ProfissionaisService : BaseService, IProfissionaisService
{
    private readonly IProfissionaisRepository _profissionaisRepository;
    private readonly ProfissionaisValidator _profissionaisValidator;

    public ProfissionaisService(IProfissionaisRepository profissionaisRepository, ProfissionaisValidator profissionaisValidator)
    {
        _profissionaisRepository = profissionaisRepository;
        _profissionaisValidator = profissionaisValidator;
    }

    public async Task<Profissional> Adicionar(Profissional profissional)
    {
        ValidationResult result = _profissionaisValidator.Validate(profissional);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _profissionaisRepository.Adicionar(profissional);
        return profissional;
    }

    public async Task<bool> Atualizar(Profissional profissional)
    {
        ValidationResult result = _profissionaisValidator.Validate(profissional);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var busca = await _profissionaisRepository.ObterPorId(profissional.Id);
        if (busca == null)
        {
            throw new Exception("Profissional não encontrada!");
        }
        await _profissionaisRepository.Atualizar(profissional.Id, profissional);
        return true;
    }

    public async Task<Profissional> ObterPorId(int id)
    {
        var profissional = await _profissionaisRepository.ObterPorId(id);
        if (profissional == null)
        {
            throw new Exception("Profissional não encontrada!");
        }
        return profissional;
    }

    public async Task<IEnumerable<Profissional>> ObterTodos()
    {
        return await _profissionaisRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _profissionaisRepository.ObterPorId(id) == null)
        {
            throw new Exception("Profissional não existe!");
        }

        await _profissionaisRepository.Remover(id);
        return true;
    }
}