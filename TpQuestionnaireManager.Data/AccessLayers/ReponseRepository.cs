using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class ReponseRepository
{
    internal TpQuestionnaireManagerDbContext DbContext { get; private set; }

    public ReponseRepository()
    {
        this.DbContext = new TpQuestionnaireManagerDbContext();
    }

    public void Create(Reponse reponse)
    {
        this.DbContext.Reponses.Add(reponse);
        this.DbContext.SaveChanges();
    }

    public void Delete(Reponse reponse)
    {
        var existingReponse = this.DbContext.Reponses.Find(reponse.Id);

        if (existingReponse is not null)
        {
            this.DbContext.Reponses.Remove(existingReponse);
            this.DbContext.SaveChanges();
        }
    }
}
