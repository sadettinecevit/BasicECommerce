using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager _storeManager;
        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            IActionResult result = null;

            DataResponse<Store> response = await _storeManager.GetById(new Guid(id));

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
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromBody]string name = null)
        {
            IActionResult result = null;

            ListDataResponse<Store> response = await _storeManager.Get(u => u.Name == name);

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
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] StoreDTO store)
        {
            IActionResult result = null;

            BaseResponse response = await _storeManager.Add(store);

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
        [HttpPost()]
        public async Task<IActionResult> Update([FromBody] StoreDTO store, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _storeManager.Update(store, new Guid(id));

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
        [HttpPost()]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            IActionResult result = null;

            BaseResponse response = await _storeManager.Delete(new Guid(id));

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
