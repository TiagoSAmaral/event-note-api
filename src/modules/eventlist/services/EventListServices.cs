/*
* eventListServices.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.EventList.Service.Interface;
using Module.Eventlist.Storage.Entity;
namespace Module.Eventlist.Service;

public class EventListServices : IEventListServices
{

    private readonly IEventListDeleteByIdentifierService deleteService;
    private readonly IEventListFetchByIdentifierService fetchByIdService;
    private readonly IEventListFetchService fetchService;
    private readonly IEventListSaveService saveService;

    public EventListServices(IEventListDeleteByIdentifierService deleteService,
                             IEventListFetchByIdentifierService fetchByIdService,
                             IEventListFetchService fetchService,
                             IEventListSaveService saveService)
    {
        this.deleteService = deleteService;
        this.fetchByIdService = fetchByIdService;
        this.fetchService = fetchService;
        this.saveService = saveService;
    }


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