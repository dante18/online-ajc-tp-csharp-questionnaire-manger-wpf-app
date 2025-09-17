using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpQuestionnaireManager.Data.Models;

[Table("Reponses")]
public class Reponse
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Texte { get; set; } = string.Empty;

    [Required]
    public int QuestionId { get; set; }

    public Question Question { get; set; } = null!;
}