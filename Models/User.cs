using System.ComponentModel.DataAnnotations;
using ChamadoSystemBackend.ValidationAttributes;

namespace ChamadoSystemBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [ValidDomain("primeplus.com.br", ErrorMessage = "O email deve ser do domínio @primeplus.com.br")]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        [AllowedRoles(ErrorMessage = "A role deve ser 'user' ou 'support'")]
        public string Role { get; set; }
    }
}
