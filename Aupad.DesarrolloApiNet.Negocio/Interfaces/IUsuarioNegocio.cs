using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface IUsuarioNegocio
    {
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorCorreoAsync(string correo);
        Task<Usuario> CrearAsync(Usuario item);
        Task<bool> ActualizarAsync(Usuario item);
        Task<bool> EliminarAsync(int id);
    }
}
