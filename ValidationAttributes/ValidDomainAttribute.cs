using System;
using System.ComponentModel.DataAnnotations;

namespace ChamadoSystemBackend.ValidationAttributes
{
    public class ValidDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            if (value is string email)
            {
                return email.EndsWith($"@{_allowedDomain}", StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
