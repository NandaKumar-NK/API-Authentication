using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class Userdetail
    {
        [Key]
        public int UserId { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
