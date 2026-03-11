namespace pzpp.Models
{
    public class CharacterTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Każdy szablon postaci jest stworzony przez jednego użytkownika (Game Master'a) 1:1
        public int CreatedByUserId { get; set; }

        // Każdy szablon postaci może mieć wiele definicji atrybutów (CharacterAttributeDefinition) 1:N
        public ICollection<CharacterAttributeDefinition> Attributes { get; set; }
    }
}
