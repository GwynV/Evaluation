using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        public string TermName { get; set; } = string.Empty;
    }
}
