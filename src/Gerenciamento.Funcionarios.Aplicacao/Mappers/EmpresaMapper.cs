using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;
using Gerenciamento.Funcionarios.Dominio.Entidades;

namespace Gerenciamento.Funcionarios.Aplicacao.Mappers;
public static class EmpresaMapper
{
    public static Empresa ToEmpresa(this EmpresaRequest request)
        => new Empresa(
            request.Id,
            request.Nome, 
            request.CNPJ, 
            request.Enderecos.Select(x => x.ToEndereco()));

    public static EmpresaResponse ToEmpresaResponse(this Empresa dominio)
        => new EmpresaResponse(
            dominio.Id,
            dominio.Nome,
            dominio.CNPJ,
            dominio.Enderecos.Select(x => x.ToEnderecoModel()));

    public static EmpresaRequest ToEmpresaRequest(this EmpresaResponse response)
        => new EmpresaRequest(
            response.Id,
            response.Nome,
            response.CNPJ,
            response.Enderecos);
}
