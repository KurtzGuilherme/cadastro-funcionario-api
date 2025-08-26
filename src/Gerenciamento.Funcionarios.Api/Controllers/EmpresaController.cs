using Gerenciamento.Funcionarios.Aplicacao.Interfaces;
using Gerenciamento.Funcionarios.Aplicacao.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.Funcionarios.Api.Controllers;

[Route("Api/v1")]
[ApiController]
public class EmpresaController : Controller
{
    private readonly IEmpresaServico _empresaServico;

    public EmpresaController(IEmpresaServico empresaServico)
    {
        _empresaServico = empresaServico;
    }

    [HttpGet]
    [Route("getEmpresa", Name = nameof(GetEmpresa))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetEmpresa([FromQuery] Guid Id)
    {
        var empresaResponse = await _empresaServico.BuscarPorIdAsync(Id);

        if(empresaResponse == null)
           return NoContent();

        return Ok(empresaResponse);
    }


    [HttpPost]
    [Route("addEmpresa", Name = nameof(AddEmpresa))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddEmpresa([FromBody] EmpresaRequest request)
    {
        await _empresaServico.AdicionarAsync(request);

        return Created();
    }

    [HttpDelete]
    [Route("deleteEmpresa", Name = nameof(DeleteEmpresa))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteEmpresa([FromBody] Guid id)
    {
        await _empresaServico.ExcluirAsync(id);

        return NoContent();
    }

    [HttpPatch]
    [Route("updateEmpresa", Name = nameof(UpdateEmpresa))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateEmpresa(EmpresaRequest request)
    {
        await _empresaServico.AtualizarAsync(request);

        return Accepted();
    }
}
