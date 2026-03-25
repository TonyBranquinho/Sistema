using Sistema.Repository;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Sistema.Service;
using Sistema.Middleware;
using Microsoft.AspNetCore.Authentication;



var builder = WebApplication.CreateBuilder(args);


// 1. Configurações Globais
QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 



// 2. Configuração do Banco de Dados (MySQL)
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// Registra os serviços como Singleton — uma instância por toda a vida da aplicação.
// PasswordService e TokenService não têm estado mutável, então Singleton é seguro
// e mais eficiente que Scoped (que criaria uma nova instância por request).
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<TokenService>();



builder.Services.AddAuthentication("jwt")
    .AddScheme<AuthenticationSchemeOptions, JwtAuthHandler>("jwt", null);

builder.Services.AddAuthorization();




// 4. CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});



// --- BUILD ---
var app = builder.Build();




// 5. Pipeline de Execução (ORDEM OBRIGATÓRIA)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles(); // Isso permite que o servidor entregue arquivos da pasta wwwroot
app.UseCors("PermitirTudo");


// ORDEM IMPORTA:
// O middleware JWT precisa rodar ANTES de UseAuthorization,
// porque ele é quem popula context.User.
// Se invertido, UseAuthorization vê um usuário anônimo e nega tudo.
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();  // 2º Autoriza (O que você pode fazer?)


app.MapControllers();
app.Run();
