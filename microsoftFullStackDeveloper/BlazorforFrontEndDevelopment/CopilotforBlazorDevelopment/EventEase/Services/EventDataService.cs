namespace EventEase.Services;

/// <summary>
/// Manages all event data and provides event operations
/// Centralizes event management for better state control
/// </summary>
public class EventDataService
{
    private readonly List<Models.Event> _events = new();
    public event Action? OnEventsChanged;

    public EventDataService()
    {
        InitializeEvents();
    }

    /// <summary>
    /// Initialize with mock data
    /// </summary>
    private void InitializeEvents()
    {
        _events.Clear();
        _events.AddRange(new List<Models.Event>
        {
            new Models.Event 
            { 
                Id = 1,
                EventName = "Annual Tech Conference 2024",
                Description = "Join industry leaders for keynote speeches, networking sessions, and hands-on workshops.",
                EventDate = DateTime.Now.AddDays(15),
                Location = "San Francisco Convention Center",
                Category = "Technology",
                MaxAttendees = 500,
                RegisteredAttendees = 342
            },
            new Models.Event 
            { 
                Id = 2,
                EventName = "Business Networking Breakfast",
                Description = "Start your morning with coffee and valuable business connections.",
                EventDate = DateTime.Now.AddDays(5),
                Location = "Downtown Hilton",
                Category = "Networking",
                MaxAttendees = 50,
                RegisteredAttendees = 45
            },
            new Models.Event 
            { 
                Id = 3,
                EventName = "C# Workshop for Beginners",
                Description = "Learn C# fundamentals with hands-on exercises and practical examples.",
                EventDate = DateTime.Now.AddDays(22),
                Location = "Tech Academy Building",
                Category = "Workshop",
                MaxAttendees = 100,
                RegisteredAttendees = 67
            },
            new Models.Event 
            { 
                Id = 4,
                EventName = "Corporate Award Ceremony",
                Description = "Celebrate excellence and company achievements with colleagues and partners.",
                EventDate = DateTime.Now.AddDays(45),
                Location = "Grand Ballroom Hotel",
                Category = "Corporate",
                MaxAttendees = 300,
                RegisteredAttendees = 156
            },
            new Models.Event 
            { 
                Id = 5,
                EventName = "Web Development Bootcamp",
                Description = "Intensive 3-day program on modern web technologies including HTML5, CSS3, and JavaScript.",
                EventDate = DateTime.Now.AddDays(30),
                Location = "Innovation Hub",
                Category = "Workshop",
                MaxAttendees = 75,
                RegisteredAttendees = 75
            }
        });
    }

    /// <summary>
    /// Gets all events
    /// </summary>
    public List<Models.Event> GetAllEvents()
    {
        return _events.Where(e => e.IsValid()).OrderBy(e => e.EventDate).ToList();
    }

    /// <summary>
    /// Gets event by ID
    /// </summary>
    public Models.Event? GetEventById(int eventId)
    {
        return _events.FirstOrDefault(e => e.Id == eventId && e.IsValid());
    }

    /// <summary>
    /// Searches events by query
    /// </summary>
    public List<Models.Event> SearchEvents(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return GetAllEvents();

        var searchTerm = query.Trim().ToLower();
        return _events
            .Where(e => e.IsValid() && (
                e.EventName.ToLower().Contains(searchTerm) ||
                e.Location.ToLower().Contains(searchTerm) ||
                e.Category.ToLower().Contains(searchTerm) ||
                e.Description.ToLower().Contains(searchTerm)
            ))
            .OrderBy(e => e.EventDate)
            .ToList();
    }

    /// <summary>
    /// Gets events by category
    /// </summary>
    public List<Models.Event> GetEventsByCategory(string category)
    {
        return _events
            .Where(e => e.IsValid() && e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .OrderBy(e => e.EventDate)
            .ToList();
    }

    /// <summary>
    /// Gets upcoming events
    /// </summary>
    public List<Models.Event> GetUpcomingEvents(int daysAhead = 30)
    {
        var cutoffDate = DateTime.Now.AddDays(daysAhead);
        return _events
            .Where(e => e.IsValid() && e.EventDate <= cutoffDate && e.EventDate > DateTime.Now)
            .OrderBy(e => e.EventDate)
            .ToList();
    }

    /// <summary>
    /// Gets available events (with seats)
    /// </summary>
    public List<Models.Event> GetAvailableEvents()
    {
        return _events
            .Where(e => e.IsValid() && e.IsAvailable)
            .OrderBy(e => e.EventDate)
            .ToList();
    }

    /// <summary>
    /// Updates event attendee count
    /// </summary>
    public bool UpdateEventAttendees(int eventId, int change)
    {
        try
        {
            var evt = _events.FirstOrDefault(e => e.Id == eventId);
            if (evt == null)
                return false;

            evt.RegisteredAttendees = Math.Max(0, Math.Min(evt.RegisteredAttendees + change, evt.MaxAttendees));
            NotifyEventsChanged();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Gets event categories
    /// </summary>
    public List<string> GetCategories()
    {
        return _events
            .Where(e => e.IsValid() && !string.IsNullOrEmpty(e.Category))
            .Select(e => e.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    private void NotifyEventsChanged()
    {
        OnEventsChanged?.Invoke();
    }
}
