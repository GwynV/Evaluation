using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class EvaluationRating
    {
        [Key]
        public int EvaluationRatingId { get; set; }
        public string EvaluationRatingName { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public int EvaluationScore { get; set; }
    }
}
