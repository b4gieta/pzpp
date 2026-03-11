namespace pzpp.Models
{
    public class Post
    {
        public int Id { get; set; }

        // Post należy do jednego wątku (Thread ma wiele postów)
        public int ThreadId { get; set; }

        // Post może być napisany przez Użytkownika (np: Game Master który nie posiada postaci)
        public int UserId { get; set; }

        // Post może być napisany jako postać (np: Przez gracza który uczęszcza w Wątku/Kampanii )
        public int? CharacterId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }


        public Thread Thread { get; set; }
        public User User { get; set; }
        public Character Character { get; set; }
    }
}
