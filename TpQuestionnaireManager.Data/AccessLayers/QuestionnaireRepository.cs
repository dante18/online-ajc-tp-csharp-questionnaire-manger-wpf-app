using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class QuestionnaireRepository
{
    internal TpQuestionnaireManagerDbContext DbContext { get; private set; }

    public QuestionnaireRepository()
    {
        this.DbContext = new TpQuestionnaireManagerDbContext();
    }

    public List<Questionnaire> GetAllQuestionnaires()
        => this.DbContext.Questionnaires.ToList();

    public void Create(Questionnaire questionnaire)
    {
        var questionnaire2 = new Questionnaire
        {
            Titre = "Questionnaire C#",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "Qu'est-ce que le CLR en .NET ?",
                    ReponsesPossibles = new List<Reponse>
                    {
                        new Reponse { Texte = "Common Language Runtime" },
                        new Reponse { Texte = "C# Language Reference" },
                        new Reponse { Texte = "Code Library Reference" }
                    }
                },
                new Question
                {
                    Text = "Quelle est la différence entre class et struct ?",
                    ReponsesPossibles = new List<Reponse>
                    {
                        new Reponse { Texte = "class = type valeur, struct = type référence" },
                        new Reponse { Texte = "struct = type valeur, class = type référence" },
                        new Reponse { Texte = "Aucune différence" }
                    }
                }
            }
        };

        // Étape 1 : insérer tout sauf la réponse attendue
        this.DbContext.Questionnaires.Add(questionnaire2);
        this.DbContext.SaveChanges();  // IDs générés

        // Étape 2 : définir la réponse attendue
        var q1 = questionnaire2.Questions.First();
        q1.ReponseAttendueId = q1.ReponsesPossibles.First(r => r.Texte == "Common Language Runtime").Id;

        var q2 = questionnaire2.Questions.Last();
        q2.ReponseAttendueId = q2.ReponsesPossibles.First(r => r.Texte == "struct = type valeur, class = type référence").Id;

        // Étape 3 : sauver la réponse attendue
        this.DbContext.SaveChanges();

        /*this.DbContext.Questionnaires.Add(questionnaire);
        this.DbContext.SaveChanges();*/
    }
}
