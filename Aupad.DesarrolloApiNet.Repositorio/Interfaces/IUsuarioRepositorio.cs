using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorCorreoAsync(string correo);
        Task<Usuario> CrearAsync(Usuario item);
        Task<bool> ActualizarAsync(Usuario item);
        Task<bool> EliminarAsync(int id);
    }
}
