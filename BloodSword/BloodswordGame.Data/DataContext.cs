using BloodswordGame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodswordGame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Връзка за Choice → два foreign key към Paragraph
            modelBuilder.Entity<Choice>()
                .HasOne(c => c.FromParagraph)
                .WithMany(p => p.Choices)
                .HasForeignKey(c => c.FromParagraphId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Choice>()
                .HasOne(c => c.ToParagraph)
                .WithMany()
                .HasForeignKey(c => c.ToParagraphId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
