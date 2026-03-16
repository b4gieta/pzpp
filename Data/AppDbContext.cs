using Microsoft.EntityFrameworkCore;
using pzpp.Models;
using Thread = pzpp.Models.Thread; // Explicit alias to resolve ambiguity

using Microsoft.EntityFrameworkCore;
using pzpp.Models;

namespace pzpp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterTemplate> CharacterTemplates { get; set; }
        public DbSet<CharacterAttributeDefinition> CharacterAttributeDefinitions { get; set; }
        public DbSet<CharacterAttributeValue> CharacterAttributeValues { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ThreadParticipant> ThreadParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite primary key for ThreadParticipant
            modelBuilder.Entity<ThreadParticipant>()
                .HasKey(tp => new { tp.UserId, tp.ThreadId });

            // Optional: configure relationships and cascade rules
            modelBuilder.Entity<ThreadParticipant>()
                .HasOne(tp => tp.User)
                .WithMany(u => u.ThreadParticipations)
                .HasForeignKey(tp => tp.UserId);

            modelBuilder.Entity<ThreadParticipant>()
                .HasOne(tp => tp.Thread)
                .WithMany(t => t.ThreadParticipants)
                .HasForeignKey(tp => tp.ThreadId);

            // Example: configure Character relationships
            modelBuilder.Entity<Character>()
                .HasOne(c => c.User)
                .WithMany(u => u.Characters)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Character>()
                 .HasOne(c => c.CharacterTemplate)
                 .WithMany(t => t.Characters) // teraz wskazuje właściwą kolekcję Character
                 .HasForeignKey(c => c.TemplateId)
                 .OnDelete(DeleteBehavior.Restrict);

            // CharacterAttributeDefinition -> Template
            modelBuilder.Entity<CharacterAttributeDefinition>()
                .HasOne(cad => cad.Template)
                .WithMany(t => t.Attributes)
                .HasForeignKey(cad => cad.TemplateId);

            // CharacterAttributeValue relationships
            modelBuilder.Entity<CharacterAttributeValue>()
                .HasOne(cav => cav.Character)
                .WithMany(c => c.Attributes)
                .HasForeignKey(cav => cav.CharacterId);

            modelBuilder.Entity<CharacterAttributeValue>()
                .HasOne(cav => cav.AttributeDefinition)
                .WithMany(ad => ad.CharacterAttributeValues)
                .HasForeignKey(cav => cav.AttributeDefinitionId);

            // Post relationships
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Thread)
                .WithMany(t => t.Posts)
                .HasForeignKey(p => p.ThreadId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Character)
                .WithMany()
                .HasForeignKey(p => p.CharacterId)
                .OnDelete(DeleteBehavior.SetNull);

            // Thread -> CreatedByUser
            modelBuilder.Entity<Thread>()
                .HasOne(t => t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId);
        }
    }
}