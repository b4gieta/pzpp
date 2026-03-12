namespace pzpp.Models
{
    public class ThreadParticipant
    {
        public int UserId { get; set; }

        // Każdy uczestnik należy do jednego wątku (Thread ma wielu uczestników)
        public int ThreadId { get; set; }
        public string Role { get; set; } // "Player" lub "Game Master"


        public Thread Thread { get; set; }
        public User User { get; set; }

    }
}
