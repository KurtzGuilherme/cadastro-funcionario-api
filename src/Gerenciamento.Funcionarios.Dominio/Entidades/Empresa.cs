using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gerenciamento.Funcionarios.Dominio.Entidades;
public class Empresa
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string CNPJ { get; private set; }
    public IEnumerable<Endereco> Enderecos { get; private set; }

    public Empresa(
        Guid id,
        string nome,
        string cnpj,
        IEnumerable<Endereco> endereco)
    {
        Id = id;
        Nome = nome;
        CNPJ = cnpj;
        Enderecos = endereco;
    }
}
