using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;

namespace Gerenciamento.Funcionarios.Data.Repositorios;
public class UsuárioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
{
    private const string _collectionName = "Usuarios";
    private readonly IMongoCollection<Usuario> _collection;

    public UsuárioRepositorio(IMongoDatabase mongoDb)
        :base(mongoDb, _collectionName)
    {
        _collection = mongoDb.GetCollection<Usuario>(_collectionName);
    }

    public async Task<Usuario?> BuscarPorEmailAsync(string email)
    {
        var filter = Builders<Usuario>.Filter
            .Eq(x => x.Email, email);

        var usuario = await _collection.Find(filter)
            .FirstOrDefaultAsync();

        return usuario;
    }
}
