using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class ConfiguracionSistemaNegocio : IConfiguracionSistemaNegocio
    {
        private readonly IConfiguracionSistemaRepositorio _repositorio;

        public ConfiguracionSistemaNegocio(IConfiguracionSistemaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ConfiguracionSistema>> ObtenerTodosAsync()
            => await _repositorio.ObtenerTodosAsync();

        public async Task<ConfiguracionSistema?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<ConfiguracionSistema?> ObtenerPorClaveAsync(string clave)
            => await _repositorio.ObtenerPorClaveAsync(clave);

        public async Task<ConfiguracionSistema> CrearAsync(ConfiguracionSistema item)
            => await _repositorio.CrearAsync(item);

        public async Task<bool> ActualizarAsync(ConfiguracionSistema item)
            => await _repositorio.ActualizarAsync(item);

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}