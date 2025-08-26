using Bogus;
using Bogus.Extensions.Brazil;
using Gerenciamento.Funcionarios.Api.Controllers;
using Gerenciamento.Funcionarios.Aplicacao.Interfaces;
using Gerenciamento.Funcionarios.Aplicacao.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;

namespace Gerenciamento.Funcionarios.Tests.Controller;
public class EmpresaControllerTests
{
    private readonly AutoMocker _autoMock;
    
    public EmpresaControllerTests()
    {
        _autoMock = new AutoMocker();
    }

    [Fact]
    public async Task GetEmpresa_EmpresaResponseNotNull_ShouldReturnOk()
    {
        // Arrange
        var controller = CreateController();
        var idFake = Guid.NewGuid();

        var empresaResponse = new Faker<EmpresaResponse>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Nome, f => f.Company.CompanyName())
            .RuleFor(x => x.CNPJ, f => f.Company.Cnpj())
            .Generate();

        _autoMock.GetMock<IEmpresaServico>()
            .Setup(m => m.BuscarPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(empresaResponse)
            .Verifiable();

        // Act
       var response = await controller.GetEmpresa(idFake);

        // Assert
        Assert.Multiple(() =>
        {
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var value = Assert.IsType<EmpresaResponse>(result.Value);
            Assert.Equal(empresaResponse.Id, value.Id);
        });
    }

    [Fact]
    public async Task GetEmpresa_WhenNotFound_ShouldReturnNoContent()
    {
        // Arrange
        var controller = CreateController();
        var idFake = Guid.NewGuid();

        _autoMock.GetMock<IEmpresaServico>()
            .Setup(m => m.BuscarPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((EmpresaResponse)null);

        // Act
        var response = await controller.GetEmpresa(idFake);

        // Assert
        Assert.IsType<NoContentResult>(response);
    }


    private EmpresaController CreateController()
        => new EmpresaController(_autoMock.GetMock<IEmpresaServico>().Object);
}
