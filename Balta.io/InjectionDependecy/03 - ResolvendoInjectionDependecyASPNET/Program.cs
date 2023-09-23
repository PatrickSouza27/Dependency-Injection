using _02___Resolvendo.Repository;
using _02___Resolvendo.Repository.Contracts;
using _02___Resolvendo.Services;
using _02___Resolvendo.Services.Contracts;
using _03___ResolvendoInjectionDependecyASPNET;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//se ele precisar resolver um problema de Interface, q por exemplo, sua classe precisa de algum ICustomerRepository no construtor, vc passa qual vc vai resolver, nesse caso, todo lugar q precisar do ICustomerRepository, vou resolver usando o CustomerRepository
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

//se pelo construtor, estiver esperando um CustomerRepository mesmo, vc resolve assim
//builder.Services.AddTransient<CustomerRepository>(); || builder.Services.AddTransient(nwe CustomerRepository);

//AddTransient <- Quero sempre uma nova Instancia 
//se dentro do IPromoCodeRepository tivesse uma dependencia de ICustomerRepository, ele daria uma nova instancia tbm

//-----------------------------------------------------------------------------------------------------------------------------\\

//AddScoped - Ele garante que o nosso objeto é unico por requisição
//resolvo o SqlConnection como?
builder.Services.AddScoped<SqlConnection>();
//No PromoCode ele precisa de uma SqlConnection assim como outra classe, então em vez de criar uma nova conexão pra esses dois casos, ele vai na memoria e pega ela
//builder.Services.AddScoped(x=> new SqlConnection("sqlconnection"));
//No Entity framework tem o addDbContext

//--------------------------------------------------------------------------------------------------------------------------\\

// agora o DeliveryFeeService depende de uma configuração, no caso, exemplo : um arquivo de configuração, q pega a Url
// normalmente esse configuration lê informações do appsettings ou de algum outro arquivo, variaveis de ambiente etc...
// essas leituras podem ter custos, e uma vez carregada, elas nunca vão mudar, isso significa q uma vez carregada, é o suficiente

builder.Services.AddSingleton<Configuration>();
// toda vez q esse item Configuration for chamado em qualquer lugar / serviço ! já tem esse item na memoria? então ele nunca vai criar
//como as configurações sempre são as mesmas, então ela nunca vai mudar, ele abrange para geral, então todo mundo vai consumir o mesmo objeto (Tomar cuidado)


var app = builder.Build();

app.MapControllers();

app.Run();
