using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Models
{
    public class user
    {

        public user()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Userdetail? User { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [MinLength(5, ErrorMessage = "Name cannot be less than 3 char")]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender cannot be empty")]
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
