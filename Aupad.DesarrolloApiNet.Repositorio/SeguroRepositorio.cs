using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class SeguroRepositorio : ISeguroRepositorio
    {
        private readonly AupadDbContext _context;

        public SeguroRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Seguro>> ObtenerTodosAsync()
        {
            return await _context.Seguros.Where(s => s.Activo).ToListAsync();
        }
        public async Task<Seguro?> ObtenerPorIdAsync(int id)
        {
            return await _context.Seguros.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Seguro> CrearAsync(Seguro item)
        {
            _context.Seguros.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(Seguro item)
        {
            _context.Seguros.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.Seguros.FindAsync(id);
             if (item == null) return false;
             item.Activo = false;
            return await _context.SaveChangesAsync() > 0;
        }
  
    }
}
