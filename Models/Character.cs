using System.Collections.Generic;

namespace pzpp.Models
{
    public class Character
    {
        public int Id { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to CharacterTemplate
        public int TemplateId { get; set; }
        public CharacterTemplate CharacterTemplate { get; set; }

        public string Name { get; set; }

        // Use bool instead of string for alive status
        public bool IsAlive { get; set; }

        // Each character can have many attribute values
        public ICollection<CharacterAttributeValue> Attributes { get; set; } = new List<CharacterAttributeValue>();
    }
}