using System.Text.Json.Serialization;

namespace Gerenciamento.Funcionarios.Aplicacao.Models.Requests;

public class UsuarioRequest
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    [JsonIgnore]
    public string Nome { get; private set; }
    [JsonIgnore]
    public byte[] PasswordHash { get; private set; }
    [JsonIgnore]
    public byte[] PasswordSalt { get; private set; }
    [JsonIgnore]
    public Guid IdFuncionario { get; private set; }

    public UsuarioRequest(
        string nome,
        string email,
        string password,
        byte[] passwordHash,
        byte[] passwordSalt,
        Guid idFuncionario)
    {
        Nome = nome;
        Email = email;
        Password = password;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        IdFuncionario = idFuncionario;
    }
}
