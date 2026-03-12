namespace pzpp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        // Hasło będzie przechowywane jako hash, a nie w postaci zwykłego tekstu
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Role { get; set; } // Admin, User
        public bool IsActive { get; set; }


        // Każdy użytkownik może mieć wiele postaci (Characters) 1:N
        public ICollection<Character> Characters { get; set; }
        // Każdy użytkownik może być zarówno graczem jak i Game Masterem w wielu wątkach.
        public ICollection<ThreadParticipant> ThreadParticipations { get; set; }
    }
}
