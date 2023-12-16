using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }
        public bool IsActive { get; set; }
        //Foreign Key from User Table
        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        //Foreign Key from Term Table
        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term? Term { get; set; }

        //Foreign Key from Term Table
        [Required]
        [Display(Name = "Grading Period")]
        public int GradingPeriodId { get; set; }
        [ForeignKey("GradingPeriodId")]
        public GradingPeriod? GradingPeriod { get; set; }
    }
}
