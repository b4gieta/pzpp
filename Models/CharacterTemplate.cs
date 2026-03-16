using System.Collections.Generic;

namespace pzpp.Models
{
    public class CharacterTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key to the User who created this template
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        // Each template can have many attribute definitions
        public ICollection<CharacterAttributeDefinition> Attributes { get; set; }
            = new List<CharacterAttributeDefinition>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
