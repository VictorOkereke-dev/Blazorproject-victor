using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class UserSession
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public UserProfile? User { get; set; }
        public List<int> ViewedEvents { get; set; } = new();
        public List<int> RegisteredEvents { get; set; } = new();
        public List<int> AttendedEvents { get; set; } = new();
        public Dictionary<string, string> Preferences { get; set; } = new();
        public string? LastSearchTerm { get; set; }
        public List<string> SearchHistory { get; set; } = new();
        public List<EventRegistration> Registrations { get; set; } = new();
        public bool IsAuthenticated => User != null;
        public int TotalEventsViewed => ViewedEvents.Count;
        public int TotalEventsRegistered => RegisteredEvents.Count;
        public int TotalEventsAttended => AttendedEvents.Count;
    }

    public class UserProfile
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;
        
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string Phone { get; set; } = string.Empty;
        
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        public List<string> Interests { get; set; } = new();
        public string PreferredLanguage { get; set; } = "en";
        public string FullName => $"{FirstName} {LastName}".Trim();
    }

    public class EventRegistration
    {
        public string RegistrationId { get; set; } = Guid.NewGuid().ToString();
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public RegistrationStatus Status { get; set; } = RegistrationStatus.Registered;
        
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;
        
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string Phone { get; set; } = string.Empty;
        
        public DateTime? AttendanceTime { get; set; }
        
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }
    }

    public enum RegistrationStatus
    {
        Registered,
        Confirmed,
        Attended,
        NoShow,
        Cancelled
    }

    public class AttendanceRecord
    {
        public string AttendanceId { get; set; } = Guid.NewGuid().ToString();
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime AttendanceTime { get; set; } = DateTime.Now;
        public AttendanceType Type { get; set; }
        public string? Notes { get; set; }
    }

    public enum AttendanceType
    {
        CheckIn,
        CheckOut,
        Late,
        Early
    }
}
