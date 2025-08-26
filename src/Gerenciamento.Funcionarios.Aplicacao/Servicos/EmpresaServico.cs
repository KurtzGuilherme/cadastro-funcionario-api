using Gerenciamento.Funcionarios.Aplicacao.Interfaces;
using Gerenciamento.Funcionarios.Aplicacao.Mappers;
using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;
using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Gerenciamento.Funcionarios.Aplicacao.Servicos;
public class EmpresaServico : IEmpresaServico
{
    private readonly IEmpresaRepositorio _empresaRepositorio;

    public EmpresaServico(IEmpresaRepositorio empresaRepositorio)
    {
        _empresaRepositorio = empresaRepositorio;
    }

    public async Task<EmpresaResponse?> BuscarPorCnpjAsync(string cnpj)
    {
        var empresa = await _empresaRepositorio.BuscarPorCnpjAsync(cnpj);


        if (empresa == null)
            return null;

        return empresa.ToEmpresaResponse();
    }

    public async Task<EmpresaResponse?> BuscarPorIdAsync(Guid id)
    {
        var empresaDominio = await _empresaRepositorio.BuscarPorIdAsync(id);

        if (empresaDominio == null)
        {
            throw new ArgumentException("Deu ruim");
        }

        if (empresaDominio == null)
            return null;

        return empresaDominio.ToEmpresaResponse();
    }

    public async Task AdicionarAsync(EmpresaRequest empresa)
    {
        var empresaDominio = empresa.ToEmpresa();

        await _empresaRepositorio.AdicionarAsync(empresaDominio);
    }

    public async Task ExcluirAsync(Guid id)
    {
        await _empresaRepositorio.ExcluirPorIdAsync(id);
    }

    public async Task AtualizarAsync(EmpresaRequest request)
    {
        var filter = new FilterDefinitionBuilder<Empresa>()
           .Where(x => x.CNPJ == request.CNPJ);

        var empresaDominio = request.ToEmpresa();

        await _empresaRepositorio.AlterarAsync(_ => filter.Inject(), empresaDominio);
    }   
}
