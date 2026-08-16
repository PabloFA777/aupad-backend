using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioNegocio(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
            => await _repositorio.ObtenerTodosAsync();

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
            => await _repositorio.ObtenerPorCorreoAsync(correo);

        public async Task<Usuario> CrearAsync(Usuario item)
        {
             item.PasswordHash = BCrypt.Net.BCrypt.HashPassword(item.PasswordHash);
            return await _repositorio.CrearAsync(item);
        }
        

        public async Task<bool> ActualizarAsync(Usuario item)
        {
            var existente = await _repositorio.ObtenerPorIdAsync(item.Id);
            if (existente == null) return false;

            // Si el PasswordHash que llega es distinto al que ya está guardado,
            // significa que el cliente envió una contraseña nueva en texto plano: hashearla.
            if (item.PasswordHash != existente.PasswordHash)
                item.PasswordHash = BCrypt.Net.BCrypt.HashPassword(item.PasswordHash);
        
            return await _repositorio.ActualizarAsync(item);
        }   

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}