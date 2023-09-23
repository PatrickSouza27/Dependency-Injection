using _05___MostrandoComoAcontece.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PrimeiroService>();
builder.Services.AddScoped<SegundoService>();
builder.Services.AddTransient<TerceiroService>();


var app = builder.Build();
// a partir do dotnet 6 não precisa usar mais o FromServices, mas os anterior precisa
app.MapGet("/", ([FromServices] PrimeiroService primeiro, SegundoService segundoService, TerceiroService terceiroService) => new {
        Id = Guid.NewGuid(),
        PrimeiroServiceId = primeiro.PrimeiroGuid,
        SegundoServiceId = new { Id = segundoService.SegundoGuid, PrimeiroServiceId = segundoService.Primeiro },
        TerceiroServiceId = new { Id = terceiroService.Id, PrimeiroServiceId = terceiroService.PrimeiroService, SegundoServiceId = terceiroService.SegundoService, SegundoServiceIdNovaInstancia = terceiroService.SegundoServiceComNovaInstancia }
    }
);

//Duplicada 1 --------------------------------------------------------------------------------------------------------------

//Chave Primeiro Service (AddSingleton) 
// - > 1abb619e-2d98-4537-8975-82150cb921c0

//Segundo Service (AddScoped)
// bb8156fa-131f-4462-838d-a48e2017dfcd",
//"segundoServiceId": "bb8156fa-131f-4462-838d-a48e2017dfcd",
//"segundoServiceIdNovaInstancia": "bb8156fa-131f-4462-838d-a48e2017dfcd"

//Terceiro Service (AddTransient) - 
//"id": "04d86115-f8fc-48bf-812d-4df41c720431",


//Duplicada 2 ------------------------------------------------------------------------------------------------------------

//Chave Primeiro Service (AddSingleton) - Cria somente uma vez a instancia e usa sempre ela
// - > 1abb619e-2d98-4537-8975-82150cb921c0

//Segundo Service (AddScoped) - Pega a mesma intancia 
/*
 "segundoServiceId": "5257d962-a61f-4b4b-a4ba-8e9e2fe86682",
 "segundoServiceIdNovaInstancia": "5257d962-a61f-4b4b-a4ba-8e9e2fe86682"
 */
//Terceiro Service (AddTransient) - Cria uma nova instancia sempre
//"id": "4fd3460c-169e-44e8-8bf8-67e57161afef"


//_Service.GetType().Name
//_Service.Select(x=> x.GetType().Name);



app.Run();
