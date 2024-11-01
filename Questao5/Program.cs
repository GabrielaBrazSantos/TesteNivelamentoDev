using FluentAssertions.Common;
using MediatR;
using Microsoft.OpenApi.Models;
using Questao5.Application.Handlers;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Generic;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Interfaces;
using Questao5.Infrastructure.Repositories;
using Questao5.Infrastructure.Services;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// INTERFACE E REPOSITORIO
builder.Services.AddScoped<IIdempotencia, IdempotenciaRepository>();
builder.Services.AddScoped<IMovimento, MovimentoRepository>();

// SERVIÇO DOMINIO
builder.Services.AddScoped<IIdempotenciaService, IdempotenciaService>();
builder.Services.AddScoped<IMovimentoService, MovimentoService>();

// APLICAÇÃO
builder.Services.AddTransient<MovimentoHandler>();
builder.Services.AddTransient<SaldoHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste.API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


