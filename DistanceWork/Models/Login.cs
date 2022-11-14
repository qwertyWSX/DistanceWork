using System.ComponentModel.DataAnnotations;

namespace DistanceWork.Models
{
    public class Login
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }
}
