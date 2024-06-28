namespace ChamadoSystemBackend.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        // Nova propriedade para primeiro acesso
        public bool IsFirstAccess { get; set; }
    }
}
