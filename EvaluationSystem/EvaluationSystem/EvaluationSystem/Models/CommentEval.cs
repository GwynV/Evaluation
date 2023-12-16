using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class CommentEval
    {
        [Key]
        public int CommentId { get; set; }
        public string EvaluationComment { get; set; } = string.Empty;
        public int CommentedById { get; set; }
        [ForeignKey("CommentedById")]
        public User? CommentedBy { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        //Foreign Key from Evaluation Table
        [Required]
        [Display(Name = "Evaluation")]
        public int EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public Evaluation? Evaluation { get; set; }


    }
}
