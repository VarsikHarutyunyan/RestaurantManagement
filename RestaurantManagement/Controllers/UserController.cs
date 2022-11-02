using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
                return BadRequest($"Item with id {id} does not exist");

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserCreateModel user)
        {
            await _userService.AddAsync(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel updateItem)
        {
            bool updateResult = await _userService.UpdateAsync(updateItem);
            if (!updateResult)
            {
                return BadRequest($"Item with id {updateItem.Id} does not exist");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }

    }
}
