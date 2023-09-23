
using _05___MostrandoComoAcontece.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IService, PrimeiroService>();  
//app.MapGet("/", (IService service) => Results.Ok(service.GetType().Name));
//Resposta ["PrimeiroService"]

//builder.Services.AddTransient<IService, PrimeiroService>();
//builder.Services.AddTransient<IService, PrimeiroService>();
//builder.Services.AddTransient<IService, SegundoService>();
//app.MapGet("/", (IService service) => Results.Ok(service.GetType().Name));
//Resposta -> Exception

//--------------------------------TryAdd---------------------------------------
//ele n deixa duplicar, é por interface
//builder.Services.TryAddTransient<IService, PrimeiroService>();
//builder.Services.TryAddTransient<IService, PrimeiroService>();
//builder.Services.TryAddTransient<IService, SegundoService>();
//app.MapGet("/", (IService service) => Results.Ok(service.GetType().Name)); Resposta - ["Primeiro Service"]
//app.MapGet("/", (IEnumerable<IService> service) => Results.Ok(service.Select(x=> x.GetType().Name))); ["Primeiro Service"]

//--------------------------------Add---------------------------------------
//ele busca sempre o ultimo, mas ele trouxe duas vezes esse ultimo
//builder.Services.AddTransient<IService, PrimeiroService>();
//builder.Services.AddTransient<IService, PrimeiroService>();
//builder.Services.AddTransient<IService, SegundoService>(); <- Erro por ter implementação diferente
//app.MapGet("/", (IEnumerable<IService> service)=> Results.Ok(service.Select(x=> x.GetType().Name)));
//Resposta -> ["PrimeiroService", "PrimeiroService"]

//--------------------------------Descriptor----------------------------

var descriptor = new ServiceDescriptor(typeof(IService), typeof(PrimeiroService), ServiceLifetime.Transient);
builder.Services.Add(descriptor);
//---------ou
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IService, PrimeiroService>());
builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimeiroService>()); // Permite
//builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IService, SegundoService>()); // Não Permite

var app = builder.Build();

app.MapGet("/", (IEnumerable<IService> service)=> Results.Ok(service.Select(x=> x.GetType().Name)));

app.Run();
public interface IService { }