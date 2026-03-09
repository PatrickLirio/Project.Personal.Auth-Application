using backend.Data;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public UserController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUser()
        {
            var users = await _userRepo.GetAllUsersAsync();
            var userDTOs = users.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();
            return Ok(userDTOs);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = "hashedpassword"
                // PasswordHash should be set after hashing the password, which is not included in this DTO
            };
            await _userRepo.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDTO);
            //return Ok("User added successfully");
        }
    }
}
