namespace Gerenciamento.Funcionarios.Dominio.Entidades;

public record Endereco
{
    public string Rua { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string CEP { get; private set; }

    public Endereco(
        string rua,
        string cidade,
        string estado,
        string cep)
    {
        Rua = rua;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;       
    }
}
