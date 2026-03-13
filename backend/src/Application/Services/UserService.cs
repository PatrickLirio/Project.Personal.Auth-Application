using backend.Application.DTOs;
using backend.Application.Interfaces;
using backend.Domain.Entitles;
using backend.Domain.Enums;



namespace backend.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IJwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UserResponseDTO> RegisterAsync(RegisterRequestDTO request)

        {

            if (await _userRepository.ExistsByEmailAsync(request.Email))

                throw new InvalidOperationException("Email already in use.");



            if (await _userRepository.ExistsByUsernameAsync(request.Username))

                throw new InvalidOperationException("Username already taken.");

             if (request.Password != request.ConfirmPassword)
        throw new InvalidOperationException("Passwords do not match.");


            var user = new User

            {

                FirstName = request.FirstName,

                LastName = request.LastName,

                Email = request.Email.ToLowerInvariant(),

                Username = request.Username,

                // BCrypt.HashPassword turns plain text into a secure hash 

                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),

                Role = UserRole.User,

                CreatedAt = DateTime.UtcNow

            };



            // Step 3: Persist to database via repository 

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();



            // Step 4: Generate JWT and return response DTO 

            var token = _jwtTokenService.GenerateToken(user);

            return MapToResponseDTO(user, token);

        }
        private static UserResponseDTO MapToResponseDTO(User user, string token) => new()

        {

            Id = user.Id,

            FirstName = user.FirstName,

            LastName = user.LastName,

            Email = user.Email,

            Username = user.Username,

            Role = user.Role.ToString(),

            Token = token

        };


    }
}
