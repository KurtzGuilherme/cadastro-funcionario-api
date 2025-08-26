using Gerenciamento.Funcionarios.Dominio.Entidades;

namespace Gerenciamento.Funcionarios.Dominio.Interfaces;
public interface IFuncionarioRepositorio : IBaseRepositorio<Funcionario>
{
    Task<Funcionario?> BuscarPorCpfAsync(string cpf);
}
