using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;
using Gerenciamento.Funcionarios.Dominio.Entidades;

namespace Gerenciamento.Funcionarios.Aplicacao.Mappers;

public static class FuncionarioMapper
{
    public static Funcionario ToFuncionario(this FuncionarioRequest request)
        => new Funcionario(
            request.Id,
            request.Nome,
            request.CPF,
            request.Email,
            request.DataNascimento,
            request.Telefone,
            request.EmpresaId,
            request.Cargo,
            request.DataContratacao,
            request.DataDesligamento,
            request.Ativo,
            request.Endereco);

    public static FuncionarioResponse ToFuncionarioResponse(this Funcionario dominio)
        => new FuncionarioResponse(
            dominio.Id,
            dominio.Nome,
            dominio.CPF,
            dominio.Email,
            dominio.DataNascimento,
            dominio.Telefone,
            dominio.EmpresaId,
            dominio.Cargo,
            dominio.DataContratacao,
            dominio.DataDesligamento,
            dominio.Ativo,
            dominio.Endereco);

    public static FuncionarioRequest ToFuncionarioRequest(this FuncionarioResponse response)
        => new FuncionarioRequest(
            response.Id,
            response.Nome,
            response.CPF,
            response.Email,
            response.DataNascimento,
            response.Telefone,
            response.EmpresaId,
            response.Cargo,
            response.DataContratacao,
            response.DataDesligamento,
            response.Ativo,
            response.Endereco);
}
