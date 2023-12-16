using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class EvaluationCategory
    {
        [Key]
        public int EvaluationCategoryId { get; set; }
        public string EvaluationCategoryName { get; set; }
    }
}
