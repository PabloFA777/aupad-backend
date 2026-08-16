using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AupadDbContext _context;

        public ClienteRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _context.Cliente.Where(c => c.Activo).ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.Id == id && c.Activo);
        }

        public async Task<Cliente> CrearAsync(Cliente item)
        {
            _context.Cliente.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(Cliente item)
        {
            _context.Cliente.Update(item);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.Cliente.FindAsync(id);
            if (item == null)
                return false;

            item.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

