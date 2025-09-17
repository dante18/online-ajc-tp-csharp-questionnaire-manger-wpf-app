using System.ComponentModel.DataAnnotations;
using TpQuestionnaireManager.Data.Models.Abstractions;

namespace TpQuestionnaireManager.Data.Models;

public class Question : IEntity
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Intitule { get; set; } = null!;

    [Required]
    public Reponse ReponseCorrecte { get; set; } = null!;

    public List<Reponse> ReponsePossible { get; set; }

    public Questionnaire Questionnaire { get; set; } = null!;
}
