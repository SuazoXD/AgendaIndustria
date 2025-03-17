using Aplication.DTOs.Usuario;

namespace Aplication.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDTO> CreateUsuarioAsync(UsuarioRequestDTO request);
        Task<IEnumerable<UsuarioResponseDTO>> GetAllUsuariosAsync();
        Task<UsuarioResponseDTO?> GetUsuarioByIdAsync(int id);
        Task<UsuarioResponseDTO?> GetUsuarioByCorreoAsync(string correo);
        Task<bool> UpdateUsuarioAsync(int id, UsuarioRequestDTO request);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
