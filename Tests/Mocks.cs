
using System.Text.Json;
using event_list.modules.eventlist.storage;

namespace event_list.Tests;

public class MockManager
{
    public List<EventFormDto>? GetEvents()
    {
      string arrayJson = @"
           [{
            ""id"": ""df632b16-6027-4881-97ef-4584ce8167eb"",
            ""title"": ""Encontro Motociclistas"",
            ""description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo."",
            ""date"": ""2025-09-17T22:22:56.254Z"",
            ""locale"": ""Rio Bonito/RJ""
          },{
            ""id"": ""649f6bed-527c-4bc9-a6a2-972a2fb0216f"",
            ""title"": ""Festa da Bananada"",
            ""description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo."",
            ""date"": ""2025-09-28T22:22:56.254Z"",
            ""locale"": ""Rio Bonito/RJ""
          },{
            ""id"": ""06b82193-b381-4fd1-97a3-209da96b3e57"",
            ""title"": ""Aniversário da Cidade"",
            ""description"": ""Evento reune barracas e lanchonetes na praça para venda de comidas típicas, bebidas e show ao vivo. Além do desfile da banda da cidade e discurso do prefeito."",
            ""date"": ""2025-09-28T22:22:56.254Z"",
            ""locale"": ""Rio Bonito/RJ""
          }]";

      return JsonSerializer.Deserialize<List<EventFormDto>>(arrayJson);
    }
}