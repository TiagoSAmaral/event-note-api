/*
* eventListFetch.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/


using Module.Eventlist.Storage.Entity;
using Module.Eventlist.Storage.Interface;

namespace Module.Eventlist.Service;

public interface IEventListFetchService
{
    IEnumerable<EventModel> Fetch();
}

public class EventListFetchService: IEventListFetchService
{
    private readonly IEventListStorage storage;

    public EventListFetchService(IEventListStorage storage)
    {
        this.storage = storage;
    }

    public IEnumerable<EventModel> Fetch()
    {
        return storage.GetAllAsync().Result;
    }
}