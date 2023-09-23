using _01_Demo.Interface;
using _01_Demo.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//o tipo vai ser resolvido durante a execução 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericsRepository<>));


var app = builder.Build();

app.MapControllers();

app.Run();
