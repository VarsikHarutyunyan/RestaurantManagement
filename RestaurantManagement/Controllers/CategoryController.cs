using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _service.GetAsync(id);

            if (user == null)
                return BadRequest($"Item with id {id} does not exist");

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateModel model)
        {
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryModel updateItem)
        {
            bool updateResult = await _service.UpdateAsync(updateItem);
            if (!updateResult)
            {
                return BadRequest($"Item with id {updateItem.Id} does not exist");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            await _service.RemoveAsync(id);
            return Ok();
        }

    }
}
