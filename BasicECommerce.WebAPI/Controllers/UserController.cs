using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IUserManager _userManager;
        public UserController(IAccountManager accountManager, IUserManager userManager)
        {
            _accountManager = accountManager;
            _userManager = userManager;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            IActionResult result = null;

            DataResponse<User> response = await _userManager.GetById(new Guid(id));

            if(response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = NotFound(response);
            }

            return result;
        }
        [HttpGet("get/{email}")]
        public async Task<IActionResult> Get([FromQuery] string email = null)
        {
            IActionResult result = null;

            ListDataResponse<User> response = await _userManager.Get(u => u.Email == email);

            if(response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = NotFound(response);
            }

            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO user)
        {
            IActionResult result = null;

            BaseResponse response = await _accountManager.Register(user);

            if(response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UserDTO user, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _userManager.Update(user, new Guid(id));

            if(response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            IActionResult result = null;
            BaseResponse retVal = await _accountManager.Login(login);

            if (retVal.IsSucces)
                result = Ok(retVal);
            else
                result = Unauthorized(retVal);

            return result;
        }
    }

}
