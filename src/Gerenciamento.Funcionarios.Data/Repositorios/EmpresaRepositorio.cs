using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;

namespace Gerenciamento.Funcionarios.Data.Repositorios;
public class EmpresaRepositorio : BaseRepositorio<Empresa>, IEmpresaRepositorio
{
    private const string _collectionName = "Empresas";
    private readonly IMongoCollection<Empresa> _collection;

    public EmpresaRepositorio(IMongoDatabase mongoDb) 
        : base(mongoDb, _collectionName)
    {
        _collection = mongoDb.GetCollection<Empresa>(_collectionName);
    }

    public async Task<Empresa?> BuscarPorCnpjAsync(string cnpj)
    {
        var filter = Builders<Empresa>.Filter
            .Eq(x => x.CNPJ, cnpj);

        var empresa = await _collection.Find(filter)
            .FirstOrDefaultAsync();

        return empresa;
    }
}
