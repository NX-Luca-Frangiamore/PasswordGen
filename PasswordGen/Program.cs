using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using PasswordGen;
using PasswordGen.Data;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory;
using PasswordGen.Service.UtenteService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<Context>("Data Source=Context.db");//il db si chiama context
builder.Services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Context")));
builder.Services.AddScoped<IManagerDb, ManagerDb>();
builder.Services.AddSingleton<FactoryBuilder>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddControllers();

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
app.Run();


