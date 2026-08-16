using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface IConfiguracionSistemaRepositorio
    {
        Task<List<ConfiguracionSistema>> ObtenerTodosAsync();
        Task<ConfiguracionSistema?> ObtenerPorIdAsync(int id);
        Task<ConfiguracionSistema?> ObtenerPorClaveAsync(string clave);
        Task<ConfiguracionSistema> CrearAsync(ConfiguracionSistema item);
        Task<bool> ActualizarAsync(ConfiguracionSistema item);
        Task<bool> EliminarAsync(int id);
    }
}
