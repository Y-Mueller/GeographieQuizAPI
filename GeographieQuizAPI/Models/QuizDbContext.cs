using Microsoft.EntityFrameworkCore;

namespace GeographieQuizAPI.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
        : base(options)
        {
        }
        public DbSet<Frage> Fragen { get; set; }
        public DbSet<Antwort> Antworten { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<FrageKategorieZuordnung> FrageKategorieZuordnung { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FrageKategorieZuordnung>()
                .HasKey(fk => new { fk.FrageID, fk.KategorieID });

            modelBuilder.Entity<FrageKategorieZuordnung>()
                .HasOne(fk => fk.Frage)
                .WithMany(f => f.FrageKategorien)
                .HasForeignKey(fk => fk.FrageID);

            modelBuilder.Entity<FrageKategorieZuordnung>()
                .HasOne(fk => fk.Kategorie)
                .WithMany(k => k.FrageKategorieZuordnung)
                .HasForeignKey(fk => fk.KategorieID);
        }
    }
}
