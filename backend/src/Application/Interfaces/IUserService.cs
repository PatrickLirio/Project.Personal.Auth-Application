using backend.Application.DTOs;
using backend.Domain.Entitles;

namespace backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> RegisterAsync(RegisterRequestDTO request);
        Task<UserResponseDTO> LoginAsync(LoginRequestDTO request);

    }
}
