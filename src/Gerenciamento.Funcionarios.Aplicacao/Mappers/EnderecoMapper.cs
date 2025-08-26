using Gerenciamento.Funcionarios.Aplicacao.Models;
using Gerenciamento.Funcionarios.Dominio.Entidades;

namespace Gerenciamento.Funcionarios.Aplicacao.Mappers;
public static class EnderecoMapper
{
    public static Endereco ToEndereco(this EnderecoModel model)
        => new Endereco(
            model.Rua,
            model.Cidade,
            model.Estado,
            model.CEP);


    public static EnderecoModel ToEnderecoModel(this Endereco dominio)
        => new EnderecoModel(
            dominio.Rua,
            dominio.Cidade,
            dominio.Estado,
            dominio.CEP);
}
