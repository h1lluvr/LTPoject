using LT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.Interfaces
{
    public interface IAuthService
    {
        // Genera un JWT para el usuario dado
        string GenerateToken(User user);

        // Opcional: valida un token y devuelve si es válido
        bool ValidateToken(string token);
    }
}
