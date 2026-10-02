using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Aupad.DesarrolloApiNet.Repositorio;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Aupad.DesarrolloApiNet.Negocio;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Api;

var builder = WebApplication.CreateBuilder(args);

// Configuración de controladores y Swagger
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Aupad API",
        Version = "v1",
        Description = "API REST del sistema de gestión de seguros AUPAD"
    });

    options.TagActionsBy(api => new[] { api.ActionDescriptor.RouteValues["controller"] });

    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Configuración del DbContext con la cadena de conexión AupadConnection
builder.Services.AddDbContext<AupadDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("AupadConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("AupadConnection"))
    ));
   // Configuración de autenticación JWT
var jwtKey = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAudience = builder.Configuration["Jwt:Audience"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization(); 

// Registro de Inyección de Dependencias (DI) - Repositorios y Negocios
builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
builder.Services.AddScoped<ITipoDocumentoNegocio, TipoDocumentoNegocio>();

builder.Services.AddScoped<ICategoriaSeguroRepositorio, CategoriaSeguroRepositorio>();
builder.Services.AddScoped<ICategoriaSeguroNegocio, CategoriaSeguroNegocio>();

builder.Services.AddScoped<ICompaniaSeguroRepositorio, CompaniaSeguroRepositorio>();
builder.Services.AddScoped<ICompaniaSeguroNegocio, CompaniaSeguroNegocio>();

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IClienteNegocio, ClienteNegocio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<IRolNegocio, RolNegocio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
builder.Services.AddScoped<ISeguroRepositorio, SeguroRepositorio>();
builder.Services.AddScoped<ISeguroNegocio, SeguroNegocio>();
builder.Services.AddScoped<IConfiguracionSistemaRepositorio, ConfiguracionSistemaRepositorio>();
builder.Services.AddScoped<IConfiguracionSistemaNegocio, ConfiguracionSistemaNegocio>();
builder.Services.AddScoped<IBeneficiarioPolizaRepositorio, BeneficiarioPolizaRepositorio>();
builder.Services.AddScoped<IBeneficiarioPolizaNegocio, BeneficiarioPolizaNegocio>();
builder.Services.AddScoped<IPolizaRepositorio, PolizaRepositorio>();
builder.Services.AddScoped<IPolizaNegocio, PolizaNegocio>();
builder.Services.AddScoped<ICuotaPolizaRepositorio, CuotaPolizaRepositorio>();
builder.Services.AddScoped<ICuotaPolizaNegocio, CuotaPolizaNegocio>();
builder.Services.AddScoped<IDocumentoPolizaRepositorio, DocumentoPolizaRepositorio>();
builder.Services.AddScoped<IDocumentoPolizaNegocio, DocumentoPolizaNegocio>();

// Configuración de CORS para permitir peticiones desde Angular (localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();


// Pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirAngular");
app.UseCustomMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
