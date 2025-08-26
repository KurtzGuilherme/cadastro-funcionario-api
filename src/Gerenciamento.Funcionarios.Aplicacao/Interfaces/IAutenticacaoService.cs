using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;

public interface IAutenticacaoService
{
    Task<bool> AutenticacaoAsync(UsuarioRequest request);
    UsuarioTokenModel GerarToken(UsuarioRequest request);
}