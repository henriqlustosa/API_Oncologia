using BackendOncologia.Interfaces;
using BackendOncologia.Logging;
using BackendOncologia.Repository;
using BackendOncologia.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Oncologia", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n" +
            "Digite 'Bearer' [espa�o] e ent�o seu token no campo abaixo. \r\n" +
            "Exemplo (informar sem aspas): 'Bearer 123abc456'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryEF>();
builder.Services.AddScoped<IMedicacaoPreQuimioRepository, MedicacaoPreQuimioRepositoryEF>();
builder.Services.AddScoped<IMedicacaoRepository, MedicacaoRepositoryEF>();
builder.Services.AddScoped<IViaDeAdministracaoRepository, ViaDeAdministracaoRepositoryEF>();
builder.Services.AddScoped<ITipoPreQuimioRepository, TipoPreQuimioRepositoryEF>();
builder.Services.AddScoped<IPreQuimioRepository, PreQuimioRepositoryEF>();
builder.Services.AddScoped<IQuimioRepository, QuimioRepositoryEF>();
builder.Services.AddScoped<IProtocolosRepository, ProtocolosRepositoryEF>();
builder.Services.AddScoped<IDescricaoProtocoloRepository, DescricaoProtocoloRepositoryEF>();
builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
//builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepositoryDapper>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();




builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

var configuration = new ConfigurationBuilder()
                          // .AddEnvironmentVariables()
                            .AddJsonFile("appsettings.json")
                          // .AddUserSecrets<Program>(true)
                            .Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Secret"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
//app.UseReDoc(c =>
//{
//    c.DocumentTitle = "REDOC Oncologia API";
//    c.RoutePrefix = "";
//});
app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
