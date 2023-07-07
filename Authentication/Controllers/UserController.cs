using Authentication.Models.DTOs;
using Authentication.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
   
        [Route("api/Register")]
        [ApiController]
        //[EnableCors("AngularCORS")]
        public class UserController : ControllerBase
        {
            private readonly IManageUser _manageUser;

            public UserController(IManageUser manageUser)
            {
                _manageUser = manageUser;
            }
            [HttpPost]
            [ProducesResponseType(typeof(UserdetailDTO), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<UserdetailDTO>> Register(UserDTO intern)
            {
                var result = await _manageUser.Register(intern);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Unable to register at this moment");
            }
        }
    
}
