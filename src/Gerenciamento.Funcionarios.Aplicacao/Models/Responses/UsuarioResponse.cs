public class UsuarioResponse
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public UsuarioResponse(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
}