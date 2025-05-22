using Challange_API_01.Application.Interfaces;
using Challange_API_01.Application.Services;
using Challange_API_01.Domain.Interfaces;
using Challange_API_01.Infrastructure.Data.AppData;
using Challange_API_01.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IHistoricoMotoRepository, HistoricoMotoRepository>();
builder.Services.AddTransient<IEstacaoRepository, EstacaoRepository>();
builder.Services.AddTransient<IMotoRepository, MotoRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
builder.Services.AddTransient<IMotoApplicationService, MotoApplicationService>();
builder.Services.AddTransient<IEstacaoApplicationService, EstacaoApplicationService>();
builder.Services.AddTransient<IHistoricoMotoApplicationService, HistoricoMotoApplicationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Mottu",
        Version = "v1",
        Description = "API para Gerenciamento de Motos"
    });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
});
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
