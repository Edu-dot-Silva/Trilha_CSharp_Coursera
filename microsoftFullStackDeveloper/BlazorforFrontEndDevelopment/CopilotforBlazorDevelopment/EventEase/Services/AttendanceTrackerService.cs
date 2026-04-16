namespace EventEase.Services;

/// <summary>
/// Tracks attendance and participation statistics for events
/// </summary>
public class AttendanceTrackerService
{
    private readonly Dictionary<int, List<AttendanceRecord>> _attendanceRecords = new();

    public class AttendanceRecord
    {
        public string UserEmail { get; set; } = string.Empty;
        public DateTime RegistrationTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public bool IsCheckedIn => CheckInTime.HasValue;
    }

    /// <summary>
    /// Records a user registration for an event
    /// </summary>
    public void RecordRegistration(int eventId, string userEmail)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(userEmail))
                throw new ArgumentException("Email cannot be empty");

            if (!_attendanceRecords.ContainsKey(eventId))
            {
                _attendanceRecords[eventId] = new List<AttendanceRecord>();
            }

            // Check if already registered
            if (_attendanceRecords[eventId].Any(r => r.UserEmail == userEmail))
            {
                throw new InvalidOperationException("User already registered for this event");
            }

            _attendanceRecords[eventId].Add(new AttendanceRecord
            {
                UserEmail = userEmail,
                RegistrationTime = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to record registration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Records user check-in for an event
    /// </summary>
    public bool RecordCheckIn(int eventId, string userEmail)
    {
        try
        {
            if (!_attendanceRecords.ContainsKey(eventId))
                return false;

            var record = _attendanceRecords[eventId].FirstOrDefault(r => r.UserEmail == userEmail);
            if (record == null)
                return false;

            if (!record.IsCheckedIn)
            {
                record.CheckInTime = DateTime.Now;
                return true;
            }

            return false; // Already checked in
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to record check-in: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Gets attendance statistics for an event
    /// </summary>
    public AttendanceStats GetEventAttendanceStats(int eventId)
    {
        if (!_attendanceRecords.ContainsKey(eventId))
        {
            return new AttendanceStats { EventId = eventId };
        }

        var records = _attendanceRecords[eventId];
        return new AttendanceStats
        {
            EventId = eventId,
            TotalRegistrations = records.Count,
            CheckedInCount = records.Count(r => r.IsCheckedIn),
            RegistrationsList = records.ToList()
        };
    }

    /// <summary>
    /// Gets all attendance statistics
    /// </summary>
    public Dictionary<int, AttendanceStats> GetAllAttendanceStats()
    {
        var stats = new Dictionary<int, AttendanceStats>();
        foreach (var eventId in _attendanceRecords.Keys)
        {
            stats[eventId] = GetEventAttendanceStats(eventId);
        }
        return stats;
    }

    /// <summary>
    /// Clears attendance records
    /// </summary>
    public void ClearRecords()
    {
        _attendanceRecords.Clear();
    }
}

public class AttendanceStats
{
    public int EventId { get; set; }
    public int TotalRegistrations { get; set; }
    public int CheckedInCount { get; set; }
    public double CheckInPercentage => TotalRegistrations > 0 ? (double)CheckedInCount / TotalRegistrations * 100 : 0;
    public List<AttendanceTrackerService.AttendanceRecord> RegistrationsList { get; set; } = new();
}
