/*
* eventListSave.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Storage.Entity;
using Module.Eventlist.Storage.Interface;

namespace Module.Eventlist.Service;

public interface IEventListSaveService
{
    void Add(EventModel data);
}
public class EventListSaveService: IEventListSaveService
{
    private readonly IEventListStorage storage;

    public EventListSaveService(IEventListStorage storage)
    {
        this.storage = storage;
    }

    public void Add(EventModel data)
    {
        storage.CreateAsync(data);
    }
}