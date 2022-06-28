using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            IActionResult result = null;

            DataResponse<Product> response = await _productManager.GetById(new Guid(id));

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
        [HttpGet("Get/{name}")]
        public async Task<IActionResult> Get([FromQuery]string name = null)
        {
            IActionResult result = null;

            ListDataResponse<Product> response = await _productManager.Get(u => u.Name == name);

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
        public async Task<IActionResult> Add([FromBody] ProductDTO product)
        {
            IActionResult result = null;

            BaseResponse response = await _productManager.Add(product);

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
        public async Task<IActionResult> Update([FromBody] ProductDTO product, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _productManager.Update(product, new Guid(id));

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

            BaseResponse response = await _productManager.Delete(new Guid(id));

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
