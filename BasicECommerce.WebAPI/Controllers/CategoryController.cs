using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            IActionResult result = null;

            DataResponse<Category> response = await _categoryManager.GetById(new Guid(id));

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

            ListDataResponse<Category> response = await _categoryManager.Get(u => u.Name == name);

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
        public async Task<IActionResult> Add([FromBody] CategoryDTO category)
        {
            IActionResult result = null;

            BaseResponse response = await _categoryManager.Add(category);

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
        public async Task<IActionResult> Update([FromBody] CategoryDTO category, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _categoryManager.Update(category, new Guid(id));

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

            BaseResponse response = await _categoryManager.Delete(new Guid(id));

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
