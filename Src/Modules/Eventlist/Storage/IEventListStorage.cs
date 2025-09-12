/*
* IStorage.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

namespace event_list.modules.eventlist.storage;

public interface IEventListStorage
{
    IEnumerable<EventListDto> GetAllAsync();
    Task<EventFormDto?> GetByIdAsync(Guid id);
    Task CreateAsync(EventFormDto entity);
    Task DeleteAsync(Guid id);
}