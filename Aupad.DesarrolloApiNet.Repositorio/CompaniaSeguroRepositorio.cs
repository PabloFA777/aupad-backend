using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class CompaniaSeguroRepositorio : ICompaniaSeguroRepositorio
    {
        private readonly AupadDbContext _context;

        public CompaniaSeguroRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompaniaSeguro>> ObtenerTodosAsync()
        {
            return await _context.CompaniaSeguro.Where(c => c.Activo).ToListAsync();
        }

        public async Task<CompaniaSeguro?> ObtenerPorIdAsync(int id)
        {
            return await _context.CompaniaSeguro.FirstOrDefaultAsync(c => c.Id == id && c.Activo);
        }

        public async Task<CompaniaSeguro> CrearAsync(CompaniaSeguro item)
        {
            _context.CompaniaSeguro.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(CompaniaSeguro item)
        {
            _context.CompaniaSeguro.Update(item);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.CompaniaSeguro.FindAsync(id);
            if (item == null)
                return false;

            item.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}