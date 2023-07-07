using Authentication.Models.DTOs;
using Authentication.Models;
using Authentication.Repository.Interface;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Repository.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, Userdetail> _userRepo;
        private readonly IRepo<int, user> _internRepo;
        private readonly IGenerateToken _tokenService;

        public ManageUserService(IRepo<int, Userdetail> userRepo,
            IRepo<int, user> internRepo,
            IGenerateToken tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
         
            _tokenService = tokenService;
        }
        public Task<UserdetailDTO> ChangeStatus(UserdetailDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserdetailDTO> Login(UserdetailDTO user)
        {
            var userData = await _userRepo.Get(user.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserdetailDTO();
                user.UserId = userData.UserId;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }

        public async Task<UserdetailDTO> Register(UserDTO intern)
        {

            UserdetailDTO user = null;
            var hmac = new HMACSHA512();
            intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(intern.Password ));
            intern.User.PasswordKey = hmac.Key;
            intern.User.Role = "intern";
            var userResult = await _userRepo.Add(intern.User);
            var internResult = await _internRepo.Add(intern);
            if (userResult != null && internResult != null)
            {
                user = new UserdetailDTO();
                user.UserId = internResult.Id;
                user.Role = userResult.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }
    }
}
