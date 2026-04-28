using Microsoft.AspNetCore.Mvc;
using WMS_API.Persistence.IServices;

namespace WMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEnity, TDto> : ControllerBase
    {
        protected readonly IBaseService<TEnity, TDto> _service;

        public BaseController(IBaseService<TEnity, TDto> service)
        {
            _service = service;
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpGet("GetDataById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
            => Ok(await _service.GetDataById(id));

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TDto dto)
            => Ok(await _service.Create(dto));

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, TDto dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }

}
