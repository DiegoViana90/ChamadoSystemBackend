using System.ComponentModel.DataAnnotations;

namespace ChamadoSystemBackend.DTOs
{
    public class UpdatePasswordDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
