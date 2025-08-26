using Gerenciamento.Funcionarios.Dominio.Entidades;

namespace Gerenciamento.Funcionarios.Dominio.Interfaces;

public interface IEmpresaRepositorio : IBaseRepositorio<Empresa>
{
    Task<Empresa?> BuscarPorCnpjAsync(string cnpj);
}
