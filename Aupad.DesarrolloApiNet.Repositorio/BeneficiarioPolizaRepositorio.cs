using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class BeneficiarioPolizaRepositorio : IBeneficiarioPolizaRepositorio
    {
        private readonly AupadDbContext _context;

        public BeneficiarioPolizaRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeneficiarioPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
        {
            return await _context.BeneficiariosPoliza.Where(b => b.PolizaId == polizaId && b.Estado == EstadoBeneficiario.Activo).ToListAsync();
        }

        public async Task<BeneficiarioPoliza?> ObtenerPorIdAsync(int id)
        {
            return await _context.BeneficiariosPoliza.FirstOrDefaultAsync(b => b.Id == id);
        }
       
         public async Task<bool> ExisteDuplicadoAsync(int polizaId, string dni, byte mes, short anio, int? excluirId = null)
        {
             return await _context.BeneficiariosPoliza.AnyAsync(b =>
            b.PolizaId == polizaId &&
            b.Dni == dni &&
            b.Mes == mes &&
            b.Anio == anio &&
            (excluirId == null || b.Id != excluirId));
        }
    
        public async Task<BeneficiarioPoliza> CrearAsync(BeneficiarioPoliza item)
        {
            _context.BeneficiariosPoliza.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(BeneficiarioPoliza item)
        {
            _context.BeneficiariosPoliza.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.BeneficiariosPoliza.FindAsync(id);
            if (item == null) return false;
            item.Estado = EstadoBeneficiario.Retirado;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
