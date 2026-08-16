using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class PolizaRepositorio : IPolizaRepositorio
    {
        private readonly AupadDbContext _context;

        public PolizaRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Poliza>> ObtenerTodosAsync()
        {
            return await _context.Polizas.ToListAsync();
        }

        public async Task<List<Poliza>> ObtenerPorClienteIdAsync(int clienteId)
        {
            return await _context.Polizas.Where(p => p.ClienteId == clienteId).ToListAsync();
        }

        public async Task<Poliza?> ObtenerPorIdAsync(int id)
        {
            return await _context.Polizas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Poliza> CrearAsync(Poliza item)
        {
            _context.Polizas.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(Poliza item)
        {
            _context.Polizas.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.Polizas.FindAsync(id);
            if (item == null) return false;
            item.Estado = EstadoPoliza.anulada;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
