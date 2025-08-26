using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Gerenciamento.Funcionarios.Data.Repositorios;
public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
{
    private readonly IMongoCollection<TEntity> _collection;

    public BaseRepositorio(IMongoDatabase mongoDb, string collectionName)
    {
        MapClasses();
        _collection = mongoDb.GetCollection<TEntity>(collectionName);
    }

    public async Task<TEntity> BuscarPorIdAsync(Guid id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        var result = await _collection.Find(filter).FirstOrDefaultAsync();

        return result;
    }

    public async Task AdicionarAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task ExcluirPorIdAsync(Guid id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
            
        await _collection.DeleteOneAsync(filter);
    }

    public async Task AlterarAsync(Expression<Func<TEntity, bool>> filterExpression, TEntity entity)
    {
        await _collection.ReplaceOneAsync(filterExpression, entity);
    }

    private void MapClasses()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
        {
            BsonClassMap.TryRegisterClassMap<TEntity>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
