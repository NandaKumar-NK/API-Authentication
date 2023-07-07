using System.Security.Principal;

namespace Authentication.Models.DTOs

{
    public class UserdetailDTO
    {
        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
