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

[Route("api/[controller]")]
[ApiController]
public class EventListController : ControllerBase
{

    private readonly IEventListServices eventListServices;

    public EventListController(IEventListServices eventListServices)
    {
        this.eventListServices = eventListServices;
    }

    [HttpGet("FetchListEvents")]
    public IActionResult GetAll() => Ok(this.eventListServices.GetAllAsync());

    [HttpGet("FetchEventById")]
    public IActionResult GetById(Guid id) => Ok(this.eventListServices.GetByIdAsync(id));

    [HttpPost("CreateNewEvent")]
    public IActionResult Create(EventModel data) => Ok(this.eventListServices.CreateAsync(data));

    [HttpDelete("DeleteEventBytId")]
    public IActionResult DeleteById(Guid id) => Ok(this.eventListServices.DeleteAsync(id));
}
