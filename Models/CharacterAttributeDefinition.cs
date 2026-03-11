namespace pzpp.Models
{
    public class CharacterAttributeDefinition
    {
        public int Id { get; set; }

        // Każda definicja atrybutu należy do jednego szablonu postaci (CharacterTemplate) 1:1
        public int TemplateId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string DefaultValue { get; set; }

        public CharacterTemplate Template { get; set; }
    }
}
