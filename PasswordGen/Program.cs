using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PasswordGen;
using PasswordGen.Data;
using PasswordGen.Repository;
using PasswordGen.Service.Autenticazione;
using PasswordGen.Service.Credenziali;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;
using PasswordGen.Service.PasswordService.GeneratorePassword.Factory;
using PasswordGen.Service.UtenteService;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json")
                                   .AddEnvironmentVariables()
                                   .Build();

builder.Services.AddSqlite<Context>("Data Source=Context.db");
builder.Services.AddDbContext<Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Context")));
builder.Services.AddScoped<IManagerDb, ManagerDb>();
builder.Services.AddSingleton<IFactory,FactoryBuilder>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddAuthentication().AddJwtBearer(config=> {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(configuration.GetValue<byte[]>("key")),
        ValidateIssuer = false,
      //  ValidIssuer= "Chi deve emette",
        ValidateAudience = false,
      //  ValidAudience="chi deve ricevere il token
    };
});
builder.Services.AddScoped<Authentication>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", policy => policy.RequireRole("user"));
});
builder.Services.AddLocalization(option => { option.ResourcesPath = "Resources"; });

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    opt.SetDefaultCulture("it-IT");
    opt.AddSupportedCultures("en-US", "it-IT");
    opt.AddSupportedUICultures("en-US", "it-IT");
});
var app = builder.Build();

app.UseRequestLocalization();
app.AddEndPointPassword().AddEndPointUtente();
app.UseAuthentication();
app.UseAuthorization();

app.Run();


