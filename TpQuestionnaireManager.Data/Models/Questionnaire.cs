using System.ComponentModel.DataAnnotations;
using TpQuestionnaireManager.Data.Models.Abstractions;

namespace TpQuestionnaireManager.Data.Models;

public class Questionnaire : IEntity
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titre { get; set; } = null!;

    List<Question> Questions { get; set; } = new List<Question>();
}
