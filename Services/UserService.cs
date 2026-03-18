using System.Text.Json;
using pzpp.Models;
namespace pzpp.Services
{
    public class UserService
    {
        private readonly string filePath = "users.json";

        public List<User> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void SaveAll(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public User? GetByLogin(string login)
        {
            return GetAll().FirstOrDefault(u => u.Login == login);
        }

        public bool UserExists(string login)
        {
            return GetAll().Any(u => u.Login == login);
        }

        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            SaveAll(users);
        }
    }
}
