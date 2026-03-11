using Microsoft.Extensions.Hosting;

namespace pzpp.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Każdy wątek/kampania jest stworzona przez jednego użytkownika (Game Master) 1:1
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Każdy wątek może mieć wiele postów (Posts) 1:N
        public ICollection<Post> Posts { get; set; }
    }
}
