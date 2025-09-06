/*
* IEventListServices.ts 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Storage.Entity;
namespace Module.EventList.Service.Interface;

public interface IEventListServices 
{
    Task<IEnumerable<EventModel>> GetAllAsync();
    Task<EventModel?> GetByIdAsync(Guid id);
    Task CreateAsync(EventModel entity);
    Task DeleteAsync(Guid id);
}