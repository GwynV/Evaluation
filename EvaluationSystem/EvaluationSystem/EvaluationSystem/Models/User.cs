using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position? Position { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

     
    }
}
