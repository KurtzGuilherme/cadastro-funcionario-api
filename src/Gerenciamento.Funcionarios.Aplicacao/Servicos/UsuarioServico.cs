using Gerenciamento.Funcionarios.Aplicacao.Interfaces;
using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;

namespace Gerenciamento.Funcionarios.Aplicacao.Servicos;

public class UsuarioServico : IUsuarioServico
{
    public UsuarioServico()
    {

    }

    public Task AdicionarAsync(UsuarioRequest request)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarAsync(UsuarioRequest funcionario)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioResponse?> BuscarPorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioResponse?> BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task ExcluirAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
