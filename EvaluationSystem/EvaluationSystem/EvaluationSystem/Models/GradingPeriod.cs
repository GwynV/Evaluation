using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class GradingPeriod
    {
        [Key]
        public int GradingPeriodId { get; set; }
        public string GradingPeriodName { get; set;} = string.Empty;
    }
}
