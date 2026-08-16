using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class CuotaPolizaRepositorio : ICuotaPolizaRepositorio
    {
        private readonly AupadDbContext _context;

        public CuotaPolizaRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<CuotaPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
        {
            return await _context.CuotasPoliza.Where(c => c.PolizaId == polizaId).ToListAsync();
        }

        public async Task<CuotaPoliza?> ObtenerPorIdAsync(int id)
        {
            return await _context.CuotasPoliza.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CuotaPoliza> CrearAsync(CuotaPoliza item)
        {
            _context.CuotasPoliza.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(CuotaPoliza item)
        {
            _context.CuotasPoliza.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.CuotasPoliza.FindAsync(id);
            if (item == null) return false;
            _context.CuotasPoliza.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
