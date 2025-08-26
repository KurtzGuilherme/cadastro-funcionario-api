using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;

namespace Gerenciamento.Funcionarios.Aplicacao.Interfaces;

public interface IUsuarioServico
{
    Task<UsuarioResponse?> BuscarPorId(Guid id);
    Task AdicionarAsync(UsuarioRequest request);
    Task AtualizarAsync(UsuarioRequest funcionario);
    Task ExcluirAsync(Guid id);
    Task<UsuarioResponse?> BuscarPorEmail(string email);

}
