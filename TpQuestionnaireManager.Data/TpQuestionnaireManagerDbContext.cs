using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data;

public class TpQuestionnaireManagerDbContext : DbContext
{
    public DbSet<Questionnaire> Questionnaires { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Reponse> Reponses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TpQuestionnaireManager;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relation Questionnaire → Questions
        modelBuilder.Entity<Questionnaire>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.Questionnaire)
            .HasForeignKey(q => q.QuestionnaireId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relation Question → Réponses
        modelBuilder.Entity<Question>()
            .HasMany(q => q.ReponsesPossibles)
            .WithOne(r => r.Question)
            .HasForeignKey(r => r.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relation Question → RéponseAttendue (1 seul)
        modelBuilder.Entity<Question>()
            .HasOne(q => q.ReponseAttendue)
            .WithMany()
            .HasForeignKey(q => q.ReponseAttendueId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
