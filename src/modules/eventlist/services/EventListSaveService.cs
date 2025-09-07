/*
* eventListSave.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System.ComponentModel.DataAnnotations;
using event_list.modules.eventlist.storage;

namespace event_list.modules.eventlist.services;

public interface IEventListSaveService
{
     Task Add(EventFormDto dto);
}
public class EventListSaveService : IEventListSaveService
{
    private readonly IEventListStorage _storage;

    public EventListSaveService(IEventListStorage storage)
    {
        _storage = storage;
    }

    public async Task Add(EventFormDto dto) {

        var results = new List<ValidationResult>();
        var context = new ValidationContext(dto);
        if (!Validator.TryValidateObject(dto, context, results, true))
        {
            throw new ValidationException(results.First().ErrorMessage);
        }
        dto.Id = Guid.NewGuid();
        await _storage.CreateAsync(dto);
    }
}