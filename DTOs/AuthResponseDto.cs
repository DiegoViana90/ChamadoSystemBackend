namespace ChamadoSystemBackend.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public UserDto? User { get; set; }
    }
}
