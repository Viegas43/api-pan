using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJETO_PAN.DTO;
using PROJETO_PAN.Models;
using PROJETO_PAN.Service;

namespace PROJETO_PAN.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {
        private readonly IUsuarioService _usuarioInterface;
        public Usuario(IUsuarioService usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }


        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            if (usuarios.Status == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int usuarioId)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(usuarioId);
            if (usuario.Status == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(usuario);
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriarDTO);
			if (usuarios.Status == System.Net.HttpStatusCode.NotFound)
			{
				return BadRequest(usuarios);
			}
			return Ok(usuarios);
		}

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioListarDTO usuarioListarDTO)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioListarDTO);
            if (usuarios.Status == System.Net.HttpStatusCode.NotFound)
            {
                return BadRequest(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpDelete]
		public async Task<IActionResult> RemoverUsuario(int usuarioId)
		{
			var usuarios = await _usuarioInterface.RemoverUsuario(usuarioId);
			if (usuarios.Status == System.Net.HttpStatusCode.NotFound)
			{
				return BadRequest(usuarios);
			}
			return Ok(usuarios);
		}

	}
}