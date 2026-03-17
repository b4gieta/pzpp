using System;

namespace pzpp.Models
{
    public class ThreadParticipant
    {
        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to Thread
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }

        // Role in the thread ("Player" or "Game Master")
        public string Role { get; set; } = string.Empty;
    }
}