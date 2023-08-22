using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<Context>("Data Source=Context.db");//il db si chiama context
builder.Services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
