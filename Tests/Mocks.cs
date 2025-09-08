
using System;
using System.Linq; 
using System.Collections.Generic;       
using System.Threading.Tasks;  
using System.Text.Json;
using event_list.modules.eventlist.storage;

namespace event_list.Tests;

public class MockManager
{
    public List<EventFormDto>? GetEvents()
    {
      string arrayJson = @"
           [{
            ""Id"": ""df632b16-6027-4881-97ef-4584ce8167eb"",
            ""Title"": ""Encontro Motociclistas"",
            ""Description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo."",
            ""Date"": ""2025-09-17T22:22:56.254Z"",
            ""Locale"": ""Rio Bonito/RJ""
          },{
            ""Id"": ""649f6bed-527c-4bc9-a6a2-972a2fb0216f"",
            ""Title"": ""Festa da Bananada"",
            ""Description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo."",
            ""Date"": ""2025-09-28T22:22:56.254Z"",
            ""Locale"": ""Rio Bonito/RJ""
          },{
            ""id"": ""06b82193-b381-4fd1-97a3-209da96b3e57"",
            ""Title"": ""Aniversário da Cidade"",
            ""Description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo. Além do desfile da banda da cidade e discurso do prefeito."",
            ""Date"": ""2025-09-28T22:22:56.254Z"",
            ""Locale"": ""Rio Bonito/RJ""
          }]";

      return JsonSerializer.Deserialize<List<EventFormDto>>(arrayJson);
    }
}