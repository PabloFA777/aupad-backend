using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AupadDbContext _context;

        public UsuarioRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.Where(u => u.Estado == EstadoUsuario.activo).ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }

        public async Task<Usuario> CrearAsync(Usuario item)
        {
            _context.Usuarios.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(Usuario item)
        {
            _context.Usuarios.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.Usuarios.FindAsync(id);
            if (item == null) return false;
            item.Estado = EstadoUsuario.inactivo;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
