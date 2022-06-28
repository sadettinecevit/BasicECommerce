using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            IActionResult result = null;

            DataResponse<Cart> response = await _cartManager.GetById(new Guid(id));

            if (response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = NotFound(response);
            }

            return result;
        }
        [HttpGet("Get/{email}")]
        public async Task<IActionResult> Get([FromQuery]string email = null)
        {
            IActionResult result = null;

            ListDataResponse<Cart> response = await _cartManager.Get(u => u.User.Email == email);

            if (response.IsSucces)
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
        public async Task<IActionResult> Add([FromBody] CartDTO cart)
        {
            IActionResult result = null;

            BaseResponse response = await _cartManager.Add(cart);

            if (response.IsSucces)
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
        public async Task<IActionResult> Update([FromBody] CartDTO cart, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _cartManager.Update(cart, new Guid(id));

            if (response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            IActionResult result = null;

            BaseResponse response = await _cartManager.Delete(new Guid(id));

            if (response.IsSucces)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }
    }
}
