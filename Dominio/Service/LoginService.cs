using Dominio.Dto;
using Dominio.Interfaces;
using Dominio.Validadores;
using Modelos.Cliente;

namespace Dominio.Service
{
    public class LoginService
    {
        private readonly IClienteRepository _clienteRepository;
        public LoginService(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Login(ClienteDto clienteDto)
        {
            if (string.IsNullOrEmpty(clienteDto.Email) && string.IsNullOrEmpty(clienteDto.Username))
                throw new Exception("Login deve ter username ou email.");
            if (string.IsNullOrEmpty(clienteDto.Senha))
                throw new Exception("Por favor digite a senha.");

            return _clienteRepository.VerificarLoginNoBanco(clienteDto)
                            ?? throw new Exception("Credenciais inválidas");
        }
    }
}
