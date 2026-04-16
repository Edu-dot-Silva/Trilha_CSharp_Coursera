namespace EventEase.Services;

/// <summary>
/// Represents a registered user session
/// </summary>
public class UserSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastActivityAt { get; set; } = DateTime.Now;
    public List<int> RegisteredEventIds { get; set; } = new();
    public bool IsActive => (DateTime.Now - LastActivityAt).TotalMinutes < 30;

    public void UpdateActivity()
    {
        LastActivityAt = DateTime.Now;
    }

    public bool IsRegisteredForEvent(int eventId)
    {
        return RegisteredEventIds.Contains(eventId);
    }

    public void RegisterForEvent(int eventId)
    {
        if (!IsRegisteredForEvent(eventId))
        {
            RegisteredEventIds.Add(eventId);
        }
    }

    public void UnregisterFromEvent(int eventId)
    {
        RegisteredEventIds.Remove(eventId);
    }
}
