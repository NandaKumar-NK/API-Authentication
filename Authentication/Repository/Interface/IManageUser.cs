using Authentication.Models.DTOs;

namespace Authentication.Repository.Interface
{
    public interface IManageUser
    {
        public Task<UserdetailDTO> Login(UserdetailDTO user);
        public Task<UserdetailDTO> Register(UserDTO intern);
        public Task<UserdetailDTO> ChangeStatus(UserdetailDTO user);
    }
}
