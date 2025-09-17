using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpQuestionnaireManager.Data.Models;

[Table("Questions")]
public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public int QuestionnaireId { get; set; }

    public Questionnaire Questionnaire { get; set; } = null!;

    public List<Reponse> ReponsesPossibles { get; set; } = new List<Reponse>();

    public int? ReponseAttendueId { get; set; }

    public Reponse? ReponseAttendue { get; set; }
}
