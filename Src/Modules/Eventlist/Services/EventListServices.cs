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

    private readonly IEventListDeleteByIdentifierService _deleteService;
    private readonly IEventListFetchByIdentifierService _fetchByIdService;
    private readonly IEventListFetchService _fetchService;
    private readonly IEventListSaveService _saveService;

    public EventListServices(IEventListDeleteByIdentifierService deleteService,
                             IEventListFetchByIdentifierService fetchByIdService,
                             IEventListFetchService fetchService,
                             IEventListSaveService saveService)
    {
        this._deleteService = deleteService;
        this._fetchByIdService = fetchByIdService;
        this._fetchService = fetchService;
        this._saveService = saveService;
    }


    public async Task CreateAsync(EventFormDto dto)
    {
        await this._saveService.Add(dto);
    }

    public async Task DeleteAsync(Guid id) => await this._deleteService.Delete(id);

    public IEnumerable<EventListDto> GetAll() => this._fetchService.Fetch();

    public async Task<EventFormDto?> GetByIdAsync(Guid id) => await this._fetchByIdService.Fetch(id);
}