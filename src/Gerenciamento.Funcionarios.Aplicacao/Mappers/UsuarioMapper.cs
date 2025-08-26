using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Dominio.Entidades;

public static class UsuarioMapper
{
    public static Usuario ToUsuario(this UsuarioRequest request)
        => new Usuario(
            request.Nome,
            request.Email,
            request.PasswordHash,
            request.PasswordSalt,
            request.IdFuncionario);
            
    public static UsuarioResponse ToUsuarioResponse(this Usuario entidade)
        => new UsuarioResponse(
            entidade.Id,
            entidade.Nome,
            entidade.Email);
}