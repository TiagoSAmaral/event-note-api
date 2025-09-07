/*
* IEventListServices.ts 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using event_list.shared.dtos;
using event_list.modules.eventlist.storage;

namespace event_list.modules.eventlist.services;
/// <summary>
/// Define a interface do modulo de Module.EventList.Service
/// </summary>
public interface IEventListServices 
{
    Task<IEnumerable<EventFormDto>> GetAllAsync();
    Task<EventFormDto?> GetByIdAsync(Guid id);
    Task CreateAsync(EventFormDto dto);
    Task DeleteAsync(Guid id);
}