using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChamadoSystemBackend.ValidationAttributes
{
    public class AllowedRolesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedRoles = { "user", "support" };

        public override bool IsValid(object value)
        {
            if (value is string role)
            {
                return _allowedRoles.Contains(role.ToLower());
            }

            return false;
        }
    }
}
