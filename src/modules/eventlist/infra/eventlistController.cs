/*
* eventlistController.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Module.Eventlist.Storage.Entity;
using Module.EventList.Service;
using Module.EventList.Service.Interface;

namespace Module.Eventlist.Infra.Controller;

[Route("api/eventos")]
[ApiController]
public class EventListController : ControllerBase
{

    private readonly IEventListServices eventListServices;

    public EventListController(IEventListServices eventListServices)
    {
        this.eventListServices = eventListServices;
    }

    // GET [HOST]/api/eventos

    /// <summary>
    /// Lista todos os Eventos
    /// </summary>
    /// <description>Retorna uma lista de eventos.</description>
    [HttpGet]
    public IActionResult GetAll() => Ok(this.eventListServices.GetAllAsync());

    // GET [HOST]/api/eventos/{id}

    /// <summary>
    /// Consulta somente um evento usando sua identificação.
    /// </summary>
    /// <param name="id"></param>
    /// <parameters>id - Identificador do evento.</parameters>
    /// <returns>Retorna um evento</returns>
    [HttpGet("id")]
    public IActionResult GetById(Guid id) => Ok(this.eventListServices.GetByIdAsync(id));

    // POST [HOST]/api/eventos

    /// <summary>
    /// Cria novo evento
    /// </summary>
    /// <param name="data"></param>
    /// <returns>Permite registrar um novo evento</returns>
    [HttpPost]
    public IActionResult Create(EventModel data) => Ok(this.eventListServices.CreateAsync(data));

    // GET [HOST]/api/eventos/{id}

    /// <summary>
    /// Apaga evento
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Permite remover um evento usando usa idenrtificação</returns>
    [HttpDelete]
    public IActionResult DeleteById(Guid id) => Ok(this.eventListServices.DeleteAsync(id));
}
