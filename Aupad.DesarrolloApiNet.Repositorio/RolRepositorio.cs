using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly AupadDbContext _context;

        public RolRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol?> ObtenerPorIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rol> CrearAsync(Rol item)
        {
            _context.Roles.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(Rol item)
        {
            _context.Roles.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.Roles.FindAsync(id);
            if (item == null) return false;
            _context.Roles.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
