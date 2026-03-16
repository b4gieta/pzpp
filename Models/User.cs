using System;
using System.Collections.Generic;

namespace pzpp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;

        // Password stored as a hash
        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        // Role: "Admin" or "User"
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<ThreadParticipant> ThreadParticipations { get; set; } = new List<ThreadParticipant>();
    }
}