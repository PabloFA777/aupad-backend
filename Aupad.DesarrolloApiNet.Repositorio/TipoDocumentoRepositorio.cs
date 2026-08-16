using Microsoft.EntityFrameworkCore;
using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
    {
        private readonly AupadDbContext _context;
        public TipoDocumentoRepositorio(AupadDbContext context)
        {
            _context = context;
        }
        public async Task<List<TipoDocumento>> ObtenerTodosAsync()
        {
            return await _context.TiposDocumento
            .Where(t=> t.Activo)
            .ToListAsync();
        }

        public async Task<TipoDocumento?> ObtenerPorIdAsync(int id)
        {
            return await _context.TiposDocumento
                .FirstOrDefaultAsync(t => t.Id == id && t.Activo);

        }

        public async Task<TipoDocumento> CrearAsync(TipoDocumento tipoDocumento)
        {
            tipoDocumento.Activo = true;
            _context.TiposDocumento.Add(tipoDocumento);
            await _context.SaveChangesAsync();
            return tipoDocumento;
        }
        
        public async Task<bool> ActualizarAsync(TipoDocumento tipoDocumento)
        {
            _context.TiposDocumento.Update(tipoDocumento);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.TiposDocumento.FindAsync(id);
            if (item == null) return false;

            item .Activo = false;
            return await _context.SaveChangesAsync() > 0; 
        }

    }
}
