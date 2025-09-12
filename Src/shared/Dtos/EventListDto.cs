namespace event_list.modules.eventlist.storage;

public class EventListDto
{
    public Guid? Id { get; set; } = null;
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
