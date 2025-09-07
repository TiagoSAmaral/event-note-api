/*
* eventlistController.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Microsoft.AspNetCore.Mvc;
using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.shared.exceptionsMessage;
using event_list.shared.response_default;

namespace event_list.modules.eventlist.infra;

[ApiController]
[Route("api/eventos")]

public class EventListController : ControllerBase
{

    private readonly IEventListServices _eventListServices;

    public EventListController(IEventListServices eventListServices)
    {
        this._eventListServices = eventListServices;
    }

    // GET [HOST]/api/eventos

    /// <summary>
    /// Lista todos os Eventos
    /// </summary>
    /// <description>Retorna uma lista de eventos.</description>
    [HttpGet]
    public IActionResult GetAllAsync() => Ok(new ResponseDefault(200, string.Empty, this._eventListServices.GetAll()));

    /// <summary>
    /// Consulta somente um evento usando sua identificação.
    /// </summary>
    /// <param name="id"></param>
    /// <parameters>id - Identificador do evento.</parameters>
    /// <returns>Retorna um evento</returns>
    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id) => Ok(new ResponseDefault(200, string.Empty, await this._eventListServices.GetByIdAsync(id)));

    /// <summary>
    /// Cria novo evento
    /// </summary>
    /// <param name="data"></param>
    /// <returns>Permite registrar um novo evento</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventFormDto dto) {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await this._eventListServices.CreateAsync(dto);
        return Ok(new ResponseDefault( 200, ExceptionsMessages.SuccessCreateEvent, null));
    }

    // GET [HOST]/api/eventos/{id}

    /// <summary>
    /// Apaga evento
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Permite remover um evento usando usa idenrtificação</returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await this._eventListServices.DeleteAsync(id);
         return Ok(new ResponseDefault( 200, ExceptionsMessages.SuccessDeleteEvent, null));
    }
}