namespace backend.Application.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
