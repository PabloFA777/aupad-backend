using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Repositorio.Data;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aupad.DesarrolloApiNet.Repositorio
{
    public class ConfiguracionSistemaRepositorio : IConfiguracionSistemaRepositorio
    {
        private readonly AupadDbContext _context;

        public ConfiguracionSistemaRepositorio(AupadDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfiguracionSistema>> ObtenerTodosAsync()
        {
            return await _context.ConfiguracionesSistema.ToListAsync();
        }

        public async Task<ConfiguracionSistema?> ObtenerPorIdAsync(int id)
        {
            return await _context.ConfiguracionesSistema.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ConfiguracionSistema?> ObtenerPorClaveAsync(string clave)
        {
            return await _context.ConfiguracionesSistema.FirstOrDefaultAsync(c => c.Clave == clave);
        }

        public async Task<ConfiguracionSistema> CrearAsync(ConfiguracionSistema item)
        {
            _context.ConfiguracionesSistema.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ActualizarAsync(ConfiguracionSistema item)
        {
            _context.ConfiguracionesSistema.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var item = await _context.ConfiguracionesSistema.FindAsync(id);
            if (item == null) return false;
            _context.ConfiguracionesSistema.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
