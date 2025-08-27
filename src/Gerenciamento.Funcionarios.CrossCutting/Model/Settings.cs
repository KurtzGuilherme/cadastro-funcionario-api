namespace Gerenciamento.Funcionarios.CrossCutting.Model;
public class Settings
{
    public MongoSettings? MongoSettings { get; set; } 
    public AuthenticationJwt? AuthenticationJwt { get; set; }
}
