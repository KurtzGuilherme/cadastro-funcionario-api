namespace Gerenciamento.Funcionarios.CrossCutting.Model;
public class AuthenticationJwt
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? SecretKey { get; set; }
}

