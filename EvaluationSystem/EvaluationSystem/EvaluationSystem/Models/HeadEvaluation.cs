using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class HeadEvaluation
    {
        [Key]
        public int HeadEvaluationId { get; set; }


        //Foreign Key from Evaluation Table
        [Required]
        [Display(Name = "Evaluation")]
        public int EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public Evaluation? Evaluation { get; set; }

        //Foreign Key from EvaluationDetails Table
        [Required]
        [Display(Name = "Evaluation Details")]
        public int EvaluationDetailsId { get; set; }
        [ForeignKey("EvaluationDetailsId")]
        public EvaluationDetails? EvaluationDetails { get; set; }
    }
}
