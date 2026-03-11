namespace pzpp.Models
{
    public class CharacterAttributeValue
    {
        public int Id { get; set; }

        // Każda wartość atrybutu należy do jednej postaci (Character) 1:1
        public int CharacterId { get; set; }

        // Każda wartość atrybutu odnosi się do jednej definicji atrybutu (CharacterAttributeDefinition) 1:1
        public int AttributeDefinitionId { get; set; }

        public string Value { get; set; }
    }
}
