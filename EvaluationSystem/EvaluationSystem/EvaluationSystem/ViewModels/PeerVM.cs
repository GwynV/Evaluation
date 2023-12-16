using EvaluationSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace EvaluationSystem.ViewModels
{
    public class PeerVM
    {
        [DisplayName("Technical Assistant")]   
       public List<User> Users { get; set; }
        public List<EvaluationCategory> Categories { get; set; }
        public List<EvaluationRating> Rating { get; set; }
        public CommentEval Comment { get; set; }
    }
}
