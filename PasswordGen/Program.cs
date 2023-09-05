using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PasswordGen;
using PasswordGen.Data;
using PasswordGen.Model.Configurator;
using PasswordGen.Repository;
using PasswordGen.Service.Autenticazione;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory;
using PasswordGen.Service.UtenteService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<Context>("Data Source=Context.db");//il db si chiama context
builder.Services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Context")));
builder.Services.AddScoped<IManagerDb, ManagerDb>();
builder.Services.AddSingleton<FactoryBuilder>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddAuthentication(o => {
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config=> {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("6ceccd7405ef4b00b2630009be568cfa")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddScoped<Authentication>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", policy => policy.RequireRole("user"));
});
builder.Services.AddLocalization(option => { option.ResourcesPath = "Resources"; });
/*builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();*/

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


