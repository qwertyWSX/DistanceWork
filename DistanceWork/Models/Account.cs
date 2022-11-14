using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistanceWork.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Company { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public int Rank { get; set; }
        [NotMappedAttribute]
        public IFormFile file { get; set; }
        public string filePath {get; set;}
    }
}
