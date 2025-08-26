using System.Security.Claims;
using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;

public class AuthenticateService : IAutenticacaoService
{
    protected readonly IUsuarioRepositorio _userRepository;
    private readonly IConfiguration _configuration;

    public AuthenticateService(IUsuarioRepositorio userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public Task<bool> AutenticacaoAsync(UsuarioRequest request)
    {

        throw new NotImplementedException();
    }
    public UsuarioTokenModel GerarToken(UsuarioRequest request)
    {
        throw new NotImplementedException();
    }
}
