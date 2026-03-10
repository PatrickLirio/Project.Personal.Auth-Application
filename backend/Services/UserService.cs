using backend.DTO;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class UserService
    {
        // field for the UserRepository
        private readonly UserRepository _userRepo;

        //constructor injection for the UserRepository
        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        //list of all users
        public async Task<List<UserDTO>> GetallUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();
            var userDTOs = users.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();
            return userDTOs;
        }

        //method to add a new user
        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            var existingUser = await _userRepo.GetUserByEmailAsync(userDTO.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = "hashedpassword"
                // PasswordHash should be set after hashing the password, which is not included in this DTO
            };
            // Call the repository method to add the user to the database
            await _userRepo.AddUserAsync(user);

            // After adding the user, you might want to return the created user with its new ID or other properties
            return userDTO;
        }
    }
}
