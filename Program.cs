using Sistema.repository;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// 1. Pega a string de conexão do seu appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

// 2. Configura o Contexto para usar MySQL com essa string
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));




builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});





var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("PermitirTudo");



app.UseHttpsRedirection();

app.UseStaticFiles(); // Isso permite que o servidor entregue arquivos da pasta wwwroot

app.UseAuthorization();

app.MapControllers();

app.Run();
