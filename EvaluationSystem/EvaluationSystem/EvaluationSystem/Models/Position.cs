    using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        public string PositionCategory { get; set; }
    }
}
