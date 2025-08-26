using System.Linq.Expressions;

namespace Gerenciamento.Funcionarios.Dominio.Interfaces;

public interface IBaseRepositorio<TEntity> where TEntity : class
{
    Task<TEntity> BuscarPorIdAsync(Guid id);
    Task AdicionarAsync(TEntity obj);
    Task ExcluirPorIdAsync(Guid id);
    Task AlterarAsync(Expression<Func<TEntity, bool>> filterExpression, TEntity entity);
    
}
