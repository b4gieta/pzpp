using System.Collections.Generic;

namespace pzpp.Models
{
    public class CharacterAttributeDefinition
    {
        public int Id { get; set; }

        // Foreign key to CharacterTemplate
        public int TemplateId { get; set; }
        public CharacterTemplate Template { get; set; }

        public string Name { get; set; }

        // Type of the attribute (e.g., "int", "string", "bool")
        public string Type { get; set; }

        // Default value stored as string
        public string DefaultValue { get; set; }

        // Navigation property for related CharacterAttributeValues
        public ICollection<CharacterAttributeValue> CharacterAttributeValues { get; set; }
            = new List<CharacterAttributeValue>();
    }
}