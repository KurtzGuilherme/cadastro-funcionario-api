using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;

namespace Gerenciamento.Funcionarios.Aplicacao.Interfaces;
public interface IEmpresaServico 
{
    Task<EmpresaResponse?> BuscarPorCnpjAsync(string cnpj);
    Task<EmpresaResponse?> BuscarPorIdAsync(Guid id);
    Task AdicionarAsync(EmpresaRequest empresa);
    Task AtualizarAsync(EmpresaRequest empresa);
    Task ExcluirAsync(Guid id);
}
