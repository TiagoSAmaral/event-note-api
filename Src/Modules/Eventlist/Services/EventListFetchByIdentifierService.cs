/*
* eventListFetchByIdentifier.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using event_list.modules.eventlist.storage;
using event_list.shared.exceptionsMessage;

namespace event_list.modules.eventlist.services;

public interface IEventListFetchByIdentifierService
{
    Task<EventFormDto?> Fetch(Guid id);
}

public class EventListFetchByIdentifierService: IEventListFetchByIdentifierService
{
    private readonly IEventListStorage _storage;

    public EventListFetchByIdentifierService(IEventListStorage storage)
    {
        this._storage = storage;
    }

    public async Task<EventFormDto?> Fetch(Guid id)
    {
        var eventF = await _storage.GetByIdAsync(id);

        if (eventF == null)
            throw new KeyNotFoundException(ExceptionsMessages.EventNotFounded);

        return eventF;
    }
}