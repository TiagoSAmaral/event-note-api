/*
* eventListDeleteByIdentifierService.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Storage.Entity;
using Module.Eventlist.Storage.Interface;

namespace Module.Eventlist.Service;

public interface IEventListDeleteByIdentifierService
{
    void Delete(Guid id);
}

public class EventListDeleteByIdentifierService: IEventListDeleteByIdentifierService
{
    private readonly IEventListStorage storage;

    public EventListDeleteByIdentifierService(IEventListStorage storage)
    {
        this.storage = storage;
    }

    public void Delete(Guid id)
    {
        storage.DeleteAsync(id);
    }
}