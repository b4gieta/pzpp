using System;
using System.Collections.Generic;

namespace pzpp.Models
{
    public class Thread
    {
        public int Id { get; set; }

        // Thread title
        public string Title { get; set; } = string.Empty;

        // Foreign key to User (creator / Game Master)
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        // Timestamp of creation
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<ThreadParticipant> ThreadParticipants { get; set; } = new List<ThreadParticipant>();
    }
}