using Aplication.DTOs.Usuario;
using Aplication.Interfaces.Usuarios;
using Domain.Entities;

namespace Aplication.Services.Usuarios
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task<UsuarioResponseDTO> CreateUsuarioAsync(UsuarioRequestDTO request)
		{
			var usuario = new Usuario
			{
				Nombre = request.Nombre,
				Correo = request.Correo,
				Contrasenia = request.Contrasenia
			};

			await _usuarioRepository.AddAsync(usuario);

			return new UsuarioResponseDTO
			{
				Id = usuario.Id,
				Nombre = usuario.Nombre,
				Correo = usuario.Correo
			};
		}

		public async Task<IEnumerable<UsuarioResponseDTO>> GetAllUsuariosAsync()
		{
			var usuarios = await _usuarioRepository.GetAllAsync();
			return usuarios.Select(u => new UsuarioResponseDTO
			{
				Id = u.Id,
				Nombre = u.Nombre,
				Correo = u.Correo
			});
		}

		public async Task<UsuarioResponseDTO?> GetUsuarioByIdAsync(int id)
		{
			var usuario = await _usuarioRepository.GetByIdAsync(id);
			return usuario == null
				? null
				: new UsuarioResponseDTO
				{
					Id = usuario.Id,
					Nombre = usuario.Nombre,
					Correo = usuario.Correo
				};
		}

		public async Task<UsuarioResponseDTO?> GetUsuarioByCorreoAsync(string correo)
		{
			var usuario = await _usuarioRepository.GetByCorreoAsync(correo);
			return usuario == null
				? null
				: new UsuarioResponseDTO
				{
					Id = usuario.Id,
					Nombre = usuario.Nombre,
					Correo = usuario.Correo
				};
		}

		public async Task<bool> UpdateUsuarioAsync(int id, UsuarioRequestDTO request)
		{
			var usuario = await _usuarioRepository.GetByIdAsync(id);
			if (usuario == null) return false;

			usuario.Nombre = request.Nombre;
			usuario.Correo = request.Correo;
			usuario.Contrasenia = request.Contrasenia;

			await _usuarioRepository.UpdateAsync(usuario);
			return true;
		}

		public async Task<bool> DeleteUsuarioAsync(int id)
		{
			var usuario = await _usuarioRepository.GetByIdAsync(id);
			if (usuario == null) return false;

			await _usuarioRepository.DeleteAsync(usuario);
			return true;
		}
	}
}
