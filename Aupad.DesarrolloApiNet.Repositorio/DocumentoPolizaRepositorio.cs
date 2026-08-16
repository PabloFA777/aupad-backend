using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class DocumentoPolizaRepositorio : IDocumentoPolizaRepositorio
    {
        private readonly AupadDbContext _context;

        public DocumentoPolizaRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentoPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
        {
            return await _context.DocumentosPoliza.Where(d => d.PolizaId == polizaId && d.Activo).ToListAsync();
        }

        public async Task<DocumentoPoliza?> ObtenerPorIdAsync(int id)
        {
            return await _context.DocumentosPoliza.FirstOrDefaultAsync(d => d.Id == id && d.Activo);
        }

        public async Task<DocumentoPoliza> CrearAsync(DocumentoPoliza item)
        {
            _context.DocumentosPoliza.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(DocumentoPoliza item)
        {
            _context.DocumentosPoliza.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.DocumentosPoliza.FindAsync(id);
            if (item == null) return false;
            item.Activo = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
