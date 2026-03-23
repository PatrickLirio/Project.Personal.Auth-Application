using backend.Domain.Enums;


namespace backend.Domain.Entitles
{
    public class User
    {
        public int Id { get; set; }
        //Display name
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //Login 
        // Username is a display name 
        public string? Username { get; set; } 
        // Email is used for login 
        public string? Email { get; set; }
        public DateTime EmailVerifiedAt { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string? LastLoginIp { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockedUntil { get; set; }

        //Security
        public string? Password { get; set; }
        public string? TempPassword { get; set; } 
        public DateTime? TemporaryPasswordExpiresAt { get; set; }
        public Status Status { get; set; } = Status.Active;
        public UserRole Role { get; set; } = UserRole.User;
        //public string? RefreshToken { get; set; }
        //public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
