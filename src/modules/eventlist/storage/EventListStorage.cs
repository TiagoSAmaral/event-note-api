/*
* EventListStorage.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

namespace event_list.modules.eventlist.storage;
public class EventListStorage : IEventListStorage
{
    private readonly ToDoListDbContext _context;

    public EventListStorage(ToDoListDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(EventFormDto entity)
    {
        await _context.Events.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem != null) {
            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
        }
    }

    public IEnumerable<EventFormDto> GetAllAsync() => _context.Events.ToList();

    public async Task<EventFormDto?> GetByIdAsync(Guid id) => await _context.Events.FindAsync(id);
}