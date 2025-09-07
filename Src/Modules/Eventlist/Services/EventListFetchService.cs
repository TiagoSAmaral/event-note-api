/*
* eventListFetch.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/



using event_list.modules.eventlist.storage;

namespace event_list.modules.eventlist.services;

public interface IEventListFetchService
{
    IEnumerable<EventFormDto> Fetch();
}

public class EventListFetchService: IEventListFetchService
{
    private readonly IEventListStorage _storage;

    public EventListFetchService(IEventListStorage storage)
    {
        this._storage = storage;
    }

    public IEnumerable<EventFormDto> Fetch()
    {
        return _storage.GetAllAsync();
    }
}