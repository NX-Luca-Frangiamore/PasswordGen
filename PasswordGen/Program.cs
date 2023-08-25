using Microsoft.EntityFrameworkCore;
using PasswordGen;
using PasswordGen.Data;
using PasswordGen.Service.Logic.LogicPassword;
using PasswordGen.Service.Logic.LogicUtente;
using PasswordGen.Service.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<Context>("Data Source=Context.db");//il db si chiama context
builder.Services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Context")));
builder.Services.AddScoped<IManagerDb, ManagerDb>();
builder.Services.AddScoped<IUtenteManager, UtenteManager>();
builder.Services.AddScoped<IPasswordManager, PasswordManager>();
builder.Services.AddControllers();

var app = builder.Build();
app.AddEndPointPassword().AddEndPointUtente();
app.Run();
