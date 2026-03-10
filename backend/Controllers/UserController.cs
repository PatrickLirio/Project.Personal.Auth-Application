using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Dependency Injection
        //field for the UserService
        private readonly UserService _userService;

        //constructor injection for the UserService
        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUser()
        {
            var user = await _userService.GetallUsersAsync();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            var user = await _userService.AddUserAsync(userDTO);
            return Ok(user);
        }
    }
}
