using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandManager _BrandManager;
        public BrandController(IBrandManager BrandManager)
        {
            _BrandManager = BrandManager;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            IActionResult result = null;

            DataResponse<Brand> response = await _BrandManager.GetById(new Guid(id));

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
        public async Task<IActionResult> Get([FromBody] string name = null)
        {
            IActionResult result = null;

            ListDataResponse<Brand> response = await _BrandManager.Get(u => u.Name == name);

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
        public async Task<IActionResult> Add([FromBody] BrandDTO brand)
        {
            IActionResult result = null;

            BaseResponse response = await _BrandManager.Add(brand);

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
        public async Task<IActionResult> Update([FromBody] BrandDTO brand, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _BrandManager.Update(brand, new Guid(id));

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

            BaseResponse response = await _BrandManager.Delete(new Guid(id));

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
