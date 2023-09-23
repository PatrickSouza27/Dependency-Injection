using _02___Resolvendo.Repository;
using _02___Resolvendo.Repository.Contracts;
using _02___Resolvendo.Services;
using _02___Resolvendo.Services.Contracts;
using _03___ResolvendoInjectionDependecyASPNET;
using _04___UsandoClasseStaticParaResolver.ExtensionMethods;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();
var connStr = builder.Configuration.GetConnectionString("Default"); //exemplo para pegar a connection string
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepository();
builder.Services.AddService();


builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
