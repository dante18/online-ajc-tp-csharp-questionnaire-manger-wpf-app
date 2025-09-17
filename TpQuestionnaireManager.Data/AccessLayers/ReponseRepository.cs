using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class ReponseRepository
{
    private readonly TpQuestionnaireManagerDbContext _context;

    public ReponseRepository(TpQuestionnaireManagerDbContext context)
    {
        _context = context;
    }

    public void Create(Reponse reponse)
    {
        this._context.Reponses.Add(reponse);
        this._context.SaveChanges();
    }
}
