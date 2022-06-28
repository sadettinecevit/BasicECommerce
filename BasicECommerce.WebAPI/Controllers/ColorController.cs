using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorManager _colorManager;
        public ColorController(IColorManager colorManager)
        {
            _colorManager = colorManager;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            IActionResult result = null;

            DataResponse<Color> response = await _colorManager.GetById(new Guid(id));

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

            ListDataResponse<Color> response = await _colorManager.Get(u => u.Name == name);

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
        public async Task<IActionResult> Add([FromBody] ColorDTO color)
        {
            IActionResult result = null;

            BaseResponse response = await _colorManager.Add(color);

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
        public async Task<IActionResult> Update([FromBody] ColorDTO color, string id)
        {
            IActionResult result = null;

            BaseResponse response = await _colorManager.Update(color, new Guid(id));

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

            BaseResponse response = await _colorManager.Delete(new Guid(id));

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
