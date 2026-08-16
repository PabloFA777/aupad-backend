using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class CategoriaSeguroRepositorio : ICategoriaSeguroRepositorio
    {
        private readonly AupadDbContext _context;

        public CategoriaSeguroRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaSeguro>> ObtenerTodosAsync()
        {
            return await _context.CategoriaSeguro.Where(c => c.Activo).ToListAsync();
        }

        public async Task<CategoriaSeguro?> ObtenerPorIdAsync(int id)
        {
            return await _context.CategoriaSeguro.FirstOrDefaultAsync(c => c.Id == id && c.Activo);
        }

        public async Task<CategoriaSeguro> CrearAsync(CategoriaSeguro item)
        {
            _context.CategoriaSeguro.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(CategoriaSeguro item)
        {
            _context.CategoriaSeguro.Update(item);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.CategoriaSeguro.FindAsync(id);
            if (item == null)
                return false;

            item.Activo = false; // soft delete
            await _context.SaveChangesAsync();
            return true;
        }
    }
}