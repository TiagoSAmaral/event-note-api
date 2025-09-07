/*
* eventListServices.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using event_list.modules.eventlist.storage;
namespace event_list.modules.eventlist.services;
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


    public async Task CreateAsync(EventFormDto dto)
    {
        await this.saveService.Add(dto);
    }

    public async Task DeleteAsync(Guid id) => await this.deleteService.Delete(id);

    public IEnumerable<EventFormDto> GetAll() => this.fetchService.Fetch();

    public async Task<EventFormDto?> GetByIdAsync(Guid id) => await this.fetchByIdService.Fetch(id);
}