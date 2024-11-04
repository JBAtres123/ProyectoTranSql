using Microsoft.EntityFrameworkCore;
using ProyectoTranSql.Models;

namespace ProyectoTranSql.Data
{
    public class AuthService
    {
        private readonly MyDbContext _context;

        public AuthService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<string> LoginAsync(string nombreUsuario, string contraseña)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null) return null;

            if (usuario.Contraseña == contraseña)
            {
                return usuario.TipoUsuario; 
            }

            return null; 
        }
    }
}
