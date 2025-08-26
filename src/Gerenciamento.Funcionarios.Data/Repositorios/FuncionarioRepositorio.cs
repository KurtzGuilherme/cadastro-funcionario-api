using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;

namespace Gerenciamento.Funcionarios.Data.Repositorios;
public class FuncionarioRepositorio : BaseRepositorio<Funcionario>, IFuncionarioRepositorio
{
    private const string _collectionName = "Funcionarios";
    private readonly IMongoCollection<Funcionario> _collection;

    public FuncionarioRepositorio(IMongoDatabase mongoDb)
         : base(mongoDb, _collectionName)
    {
        _collection = mongoDb.GetCollection<Funcionario>(_collectionName);
    }

    public async Task<Funcionario?> BuscarPorCpfAsync(string cpf)
    {
        var filter = Builders<Funcionario>.Filter
            .Eq(x => x.CPF, cpf);

        var funcionario = await _collection.Find(filter)
            .FirstOrDefaultAsync();

        return funcionario;
    }
}
