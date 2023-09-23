using _01_Demo.Interface;
using _01_Demo.Repository;
using _01_Demo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

/*
 public void ConfigureService(IServiceCollection service){
    service.AddScoped<IClienteService, ClienteService>();
    service.AddScoped<IClienteRepository, ClienteRepository>();
} 
 */

var app = builder.Build();

app.MapControllers();

app.Run();
