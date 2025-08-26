using Gerenciamento.Funcionarios.CrossCutting.Middleware;
using Gerenciamento.Funcionarios.CrossCutting.Model;
using Gerenciamento.Funcionarios.CrossCutting.Mongo;
using Gerenciamento.Funcionarios.CrossCutting.Repositorios;
using Gerenciamento.Funcionarios.CrossCutting.Servicos;
using Gerenciamento.Funcionarios.CrossCutting.Validacoes;
using Gerenciamento.Funcionarios.CrossCutting.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var applicationSettings = builder.Configuration.GetSection("Settings").Get<Settings>();

builder.Services.AddControllers();

builder.Services
    .AddRepositorios()
    .AddServicos()
    .AddMongo(applicationSettings!.MongoSettings!)
    .AddAuthenticationJwt(applicationSettings!.AuthenticationSettings!)
    .AddValidacao()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddNewtonsoftJson();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
