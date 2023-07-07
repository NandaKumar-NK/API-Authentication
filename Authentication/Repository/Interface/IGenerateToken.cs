using Authentication.Models.DTOs;

namespace Authentication.Repository.Interface
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserdetailDTO user);
    }
}
