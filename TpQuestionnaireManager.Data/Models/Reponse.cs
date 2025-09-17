using System.ComponentModel.DataAnnotations;
using TpQuestionnaireManager.Data.Models.Abstractions;

namespace TpQuestionnaireManager.Data.Models;

public class Reponse : IEntity
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nom { get; set; } = null!;
}
