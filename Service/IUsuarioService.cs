using PROJETO_PAN.DTO;
using PROJETO_PAN.Models;

namespace PROJETO_PAN.Service

{
    public interface IUsuarioService
    {
        Task<ResponseModel<List<UsuarioListarDTO>>>BuscarUsuarios();
        Task<ResponseModel<Usuario>> BuscarUsuarioPorId(int usuarioId);
        Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO);
		Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioListarDTO usuarioListarDTO);
        Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(int usuarioId);
	}
}
