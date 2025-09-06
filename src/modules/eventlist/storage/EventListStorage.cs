/*
* EventListStorage.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Storage.Entity;
using Module.Eventlist.Storage.Interface;

public class EventListStorage : IEventListStorage
{
    public Task CreateAsync(EventModel entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EventModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EventModel?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}