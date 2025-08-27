namespace Gerenciamento.Funcionarios.Data.Proxy.Interface;
public interface IAutenticacaoProxy
{
    Task<string> GetToken();

    bool TokenExpirado();
}
