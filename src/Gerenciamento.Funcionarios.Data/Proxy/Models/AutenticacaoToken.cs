namespace Gerenciamento.Funcionarios.Data.Proxy.Models;

public class AutenticacaoToken
{
    public string TokenAcesso { get; set; }

    public string TokenTipo { get; set; }

    public int ExpiraEm { get; set; }

    public DateTime DataExpiracao { get; set; }


    public AutenticacaoToken()
    {
        DataExpiracao = DateTime.MinValue;
    }
}
