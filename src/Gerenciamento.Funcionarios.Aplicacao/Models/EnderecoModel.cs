namespace Gerenciamento.Funcionarios.Aplicacao.Models;
public class EnderecoModel
{
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }

    public EnderecoModel(
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
