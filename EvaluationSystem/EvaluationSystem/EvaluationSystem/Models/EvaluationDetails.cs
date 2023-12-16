using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationSystem.Models
{
    public class EvaluationDetails
    {
        [Key]
        public int EvaluationDetailsId { get; set; }

        //Foreign Key from EvaluationCategory Table
        [Required]
        [Display(Name = "Evaluation Category")]
        public int EvaluationCategoryId { get; set; }
        [ForeignKey("EvaluationCategoryId")]
        public EvaluationCategory? EvaluationCategory { get; set; }

        //Foreign Key from EvaluationRating Table
        [Required]
        [Display(Name = "Evaluation Rating")]
        public int EvaluationRatingId { get; set; }
        [ForeignKey("EvaluationRatingId")]
        public EvaluationRating? EvaluationRating { get; set; }

       
        //Foreign Key from Evaluation Table
        [Required]
        public int EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public Evaluation? Evaluation { get; set; }

        //
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        //Foreign Key from  Table
        [Required]
        [Display(Name = "Evaluated User")]
        public int EvaluatedUserId { get; set; }
        [ForeignKey("EvaluatedUserId")]
        public User? EvaluatedUser { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
