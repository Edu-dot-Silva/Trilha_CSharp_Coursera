namespace EventEase.Services;

/// <summary>
/// Manages user session state throughout the application
/// Provides session tracking and user-specific event registrations
/// </summary>
public class SessionStateService
{
    private UserSession? _currentSession;
    private readonly List<UserSession> _sessions = new();
    public event Action? OnSessionChanged;

    public UserSession? CurrentSession => _currentSession;
    
    public bool IsSessionActive => _currentSession?.IsActive ?? false;

    /// <summary>
    /// Starts a new user session
    /// </summary>
    public UserSession CreateSession(string userName, string email, string? phone = null, string? company = null)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("User name cannot be empty");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            _currentSession = new UserSession
            {
                UserName = userName.Trim(),
                Email = email.Trim(),
                Phone = phone?.Trim(),
                Company = company?.Trim()
            };

            _sessions.Add(_currentSession);
            NotifySessionChanged();
            return _currentSession;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to create session: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Resumes an existing session
    /// </summary>
    public UserSession? GetSession(string sessionId)
    {
        var session = _sessions.FirstOrDefault(s => s.SessionId == sessionId);
        if (session?.IsActive ?? false)
        {
            _currentSession = session;
            _currentSession.UpdateActivity();
            NotifySessionChanged();
            return session;
        }
        return null;
    }

    /// <summary>
    /// Registers user for an event
    /// </summary>
    public bool RegisterUserForEvent(int eventId)
    {
        try
        {
            if (_currentSession == null)
                return false;

            _currentSession.RegisterForEvent(eventId);
            _currentSession.UpdateActivity();
            NotifySessionChanged();
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to register for event: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Unregisters user from an event
    /// </summary>
    public bool UnregisterUserFromEvent(int eventId)
    {
        try
        {
            if (_currentSession == null)
                return false;

            _currentSession.UnregisterFromEvent(eventId);
            _currentSession.UpdateActivity();
            NotifySessionChanged();
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to unregister from event: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Gets all user registrations
    /// </summary>
    public List<int> GetUserRegistrations()
    {
        return _currentSession?.RegisteredEventIds.ToList() ?? new List<int>();
    }

    /// <summary>
    /// Ends current session
    /// </summary>
    public void EndSession()
    {
        _currentSession = null;
        NotifySessionChanged();
    }

    /// <summary>
    /// Gets count of active sessions
    /// </summary>
    public int GetActiveSessionCount()
    {
        return _sessions.Count(s => s.IsActive);
    }

    /// <summary>
    /// Gets all sessions for admin purposes
    /// </summary>
    public List<UserSession> GetAllSessions()
    {
        return _sessions.ToList();
    }

    private void NotifySessionChanged()
    {
        OnSessionChanged?.Invoke();
    }
}
