using EvaluationSystem.Models;
using System.ComponentModel;

namespace EvaluationSystem.ViewModels
{
    public class HeadVM
    {
        [DisplayName("Technical Assistant")]
        public List<User> Users { get; set; }
        public List<EvaluationCategory> Categories { get; set; }
        public List<EvaluationRating> Rating { get; set; }
        public CommentEval Comment { get; set; }
    }
}
