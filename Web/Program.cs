using Dominio;
using Infra;
using Microsoft.EntityFrameworkCore;

var db = new BeautyContext();
var migracoesPendentes = db.Database.GetPendingMigrations();
if (migracoesPendentes.Count() > 0)
{
    db.Database.Migrate();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ModuloInjecaoDominio.RegistrarServico(builder.Services);
ModuloDeInjecaoDaInfra.RegistrarServicos(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
