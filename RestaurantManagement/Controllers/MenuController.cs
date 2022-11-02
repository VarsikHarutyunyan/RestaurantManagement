using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
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
        public async Task<IActionResult> Create([FromBody] MenuCreateModel model)
        {
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MenuModel updateItem)
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
