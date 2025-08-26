using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;

namespace Gerenciamento.Funcionarios.Aplicacao.Interfaces;

public interface IFuncionarioServico
{
    Task<FuncionarioResponse?> BuscarPorIdAsync(Guid id);
    Task AdicionarAsync(FuncionarioRequest funcionario);
    Task AtualizarAsync(FuncionarioRequest funcionario);
    Task ExcluirAsync(Guid id);
    Task<FuncionarioResponse?> BuscarPorCpfAsync(string cpf);
}
