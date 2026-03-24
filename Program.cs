using Sistema.Repository;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Sistema.Service;

var builder = WebApplication.CreateBuilder(args);


// 1. Configurações Globais
QuestPDF.Settings.License = LicenseType.Community;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Sistema.Service.TokenService>(); 



// 2. Configuração do Banco de Dados (MySQL)
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// 3. Configuração do JWT
var secretKey = builder.Configuration["JwtSettings:Secret"];
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // Mudar para true em produção
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        
        ValidateIssuer = true,
        ValidIssuer = "MeuSistemaAPI",

        ValidateAudience = true,
        ValidAudience = "UsuariosApp",

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});



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


app.UseAuthentication(); // 1º Autentica (Quem é você?)
app.UseAuthorization();  // 2º Autoriza (O que você pode fazer?)


app.MapControllers();
app.Run();
