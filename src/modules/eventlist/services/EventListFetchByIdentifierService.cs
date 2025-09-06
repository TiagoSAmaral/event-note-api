/*
* eventListFetchByIdentifier.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Storage.Entity;
using Module.Eventlist.Storage.Interface;

namespace Module.Eventlist.Service;

public interface IEventListFetchByIdentifierService
{
    EventModel? Fetch(Guid id);
}

public class EventListFetchByIdentifierService: IEventListFetchByIdentifierService
{
    private readonly IEventListStorage storage;

    public EventListFetchByIdentifierService(IEventListStorage storage)
    {
        this.storage = storage;
    }

    public EventModel? Fetch(Guid id)
    {
        return storage.GetByIdAsync(id).Result;
    }
}