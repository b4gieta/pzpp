namespace pzpp.Models
{
    public class Character
    {
        public int Id { get; set; }

        // Każda postać należy do jednego użytkownika (User) 1:1
        public int UserId { get; set; }

        // Każda postać jest oparta na jednym szablonie (CharacterTemplate) 1:1
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string IsAlive { get; set; }

        // Każda postać ma wiele wartości atrybutów (CharacterAttributeValue) 1:N
        public ICollection<CharacterAttributeValue> Attributes { get; set; }
        
        public User User { get; set; }
        public CharacterTemplate CharacterTemplate { get; set; }
    }
}
