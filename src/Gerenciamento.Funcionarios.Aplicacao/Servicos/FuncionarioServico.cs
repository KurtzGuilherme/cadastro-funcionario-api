using Gerenciamento.Funcionarios.Aplicacao.Interfaces;
using Gerenciamento.Funcionarios.Aplicacao.Mappers;
using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;
using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Gerenciamento.Funcionarios.Aplicacao.Servicos;
public class FuncionarioServico : IFuncionarioServico
{
    private readonly IFuncionarioRepositorio _funcionarioRepositorio;

    public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio)
    {
        _funcionarioRepositorio = funcionarioRepositorio;
    }

    public async Task<FuncionarioResponse?> BuscarPorIdAsync(Guid id)
    {
        var funcionario = await _funcionarioRepositorio.BuscarPorIdAsync(id);

        if (funcionario == null)
            return null;

        return funcionario.ToFuncionarioResponse();
    }

    public async Task<FuncionarioResponse?> BuscarPorCpfAsync(string cpf)
    {
        var funcionario = await _funcionarioRepositorio.BuscarPorCpfAsync(cpf);

        if (funcionario == null)
            return null;

        return funcionario.ToFuncionarioResponse();
    }

    public async Task AdicionarAsync(FuncionarioRequest request)
    {
        var funcionario = request.ToFuncionario();

        await _funcionarioRepositorio.AdicionarAsync(funcionario);
    }

    public async Task ExcluirAsync(Guid id)
    {
        await _funcionarioRepositorio.ExcluirPorIdAsync(id);
    }

    public async Task AtualizarAsync(FuncionarioRequest request)
    {
        var filter = new FilterDefinitionBuilder<Funcionario>()
          .Where(x => x.Id == request.Id);

        var funcionarioDominio = request.ToFuncionario();
        
        await _funcionarioRepositorio.AlterarAsync(_ => filter.Inject(), funcionarioDominio);
    }
}
