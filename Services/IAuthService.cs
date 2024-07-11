using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadoSystemBackend.Services
{
    public interface IAuthService
    {
        AuthResponse Authenticate(string email, string password);
    }
}