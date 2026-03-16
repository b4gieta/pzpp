using System.Collections.Generic;
namespace pzpp.Models
{
    public class CharacterAttributeValue
    {
        public int Id { get; set; }

        // Foreign key to Character
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        // Foreign key to CharacterAttributeDefinition
        public int AttributeDefinitionId { get; set; }
        public CharacterAttributeDefinition AttributeDefinition { get; set; }

        // Value stored as string
        public string Value { get; set; }
    }
}