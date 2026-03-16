using System;

namespace pzpp.Models
{
    public class Post
    {
        public int Id { get; set; }

        // Foreign key to Thread
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }

        // Foreign key to User (author)
        public int UserId { get; set; }
        public User User { get; set; }

        // Optional foreign key to Character (author as a character)
        public int? CharacterId { get; set; }
        public Character Character { get; set; }

        // Content of the post
        public string Content { get; set; } = string.Empty;

        // Timestamp
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}