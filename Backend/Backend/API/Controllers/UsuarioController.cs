using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs.Usuario;
using Aplication.Interfaces.Usuarios;

namespace API.Controllers
{
    [Authorize] // 🔒 Protege TODOS los endpoints dentro de este controlador
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // 🔒 Requiere autenticación JWT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        // 🔓 Permitir crear usuario sin autenticación (ejemplo de registro)
        [HttpPost]
        [AllowAnonymous] // ❌ No requiere token
        public async Task<ActionResult<UsuarioResponseDTO>> CrearUsuario(UsuarioRequestDTO request)
        {
            var usuario = await _usuarioService.CreateUsuarioAsync(request);
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
        }

        [HttpPost("crear")]
        [Authorize] // Solo los usuarios autenticados pueden crear otros usuarios
        public async Task<ActionResult<UsuarioResponseDTO>> CrearNuevoUsuario(UsuarioRequestDTO request)
        {
            var usuario = await _usuarioService.CreateUsuarioAsync(request);
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
        }  


    }
}
