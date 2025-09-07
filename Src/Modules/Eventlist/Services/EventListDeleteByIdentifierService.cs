/*
* eventListDeleteByIdentifierService.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using event_list.modules.eventlist.storage;

namespace event_list.modules.eventlist.services;
public interface IEventListDeleteByIdentifierService
{
    Task Delete(Guid id);
}

public class EventListDeleteByIdentifierService: IEventListDeleteByIdentifierService
{
    private readonly IEventListStorage _storage;

    public EventListDeleteByIdentifierService(IEventListStorage storage)
    {
        this._storage = storage;
    }

    public async Task Delete(Guid id) => await _storage.DeleteAsync(id);
}