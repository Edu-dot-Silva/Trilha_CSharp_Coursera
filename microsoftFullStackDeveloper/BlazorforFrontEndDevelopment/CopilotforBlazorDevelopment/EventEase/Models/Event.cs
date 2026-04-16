namespace EventEase.Models;

/// <summary>
/// Data model for event information
/// Used to store and manage event details throughout the application
/// </summary>
public class Event
{
    private string _eventName = string.Empty;
    private string _description = string.Empty;
    private string _location = string.Empty;
    private string _category = string.Empty;
    private int _maxAttendees;
    private int _registeredAttendees;

    public int Id { get; set; }

    public string EventName
    {
        get => _eventName;
        set => _eventName = value?.Trim() ?? string.Empty;
    }

    public string Description
    {
        get => _description;
        set => _description = value?.Trim() ?? string.Empty;
    }

    public DateTime EventDate { get; set; }

    public string Location
    {
        get => _location;
        set => _location = value?.Trim() ?? string.Empty;
    }

    public string Category
    {
        get => _category;
        set => _category = value?.Trim() ?? string.Empty;
    }

    public int MaxAttendees
    {
        get => _maxAttendees;
        set => _maxAttendees = Math.Max(0, value);
    }

    public int RegisteredAttendees
    {
        get => _registeredAttendees;
        set => _registeredAttendees = Math.Max(0, Math.Min(value, MaxAttendees));
    }

    public bool IsAvailable => RegisteredAttendees < MaxAttendees;

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(EventName) &&
               !string.IsNullOrWhiteSpace(Location) &&
               EventDate > DateTime.Now &&
               MaxAttendees > 0;
    }
}
