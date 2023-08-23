using Microsoft.EntityFrameworkCore;
using PasswordGen;
using PasswordGen.Model;
using PasswordGen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<Context>("Data Source=Context.db");//il db si chiama context
builder.Services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Context")));
builder.Services.AddScoped<IManagerDb, ManagerDb>();
builder.Services.AddControllers();

var app = builder.Build();

app.AddEndPointPassword().AddEndPointUtente();

app.Run();
