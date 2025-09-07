/*
* EventListDbContext.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/


using Microsoft.EntityFrameworkCore;

namespace event_list.modules.eventlist.storage;

public class EventListDbContext : DbContext
{
    public DbSet<EventFormDto> Events => Set<EventFormDto>();
    
    public EventListDbContext(DbContextOptions<EventListDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<EventFormDto>(ev =>
        {
            ev.HasKey(entity => entity.Id);
            ev.Property(entity => entity.Title).IsRequired();
            ev.Property( entity => entity.Description).IsRequired();
            ev.Property( entity => entity.Locale).IsRequired();
        });
    }
}