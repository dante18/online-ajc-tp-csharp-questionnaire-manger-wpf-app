using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data;

public class TpQuestionnaireManagerDbContext : DbContext
{
    public DbSet<Questionnaire> Questionnaires { get; set; }

    public DbSet<Question> Questions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TpQuestionnaireManager;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
