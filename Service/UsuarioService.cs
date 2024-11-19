using AutoMapper;
using Dapper;
using PROJETO_PAN.DTO;
using PROJETO_PAN.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace PROJETO_PAN.Service

{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration; 
        private readonly IMapper _mapper;
        private object connection;

        public UsuarioService(IConfiguration configuration, IMapper mapper) 
        { 
            _configuration = configuration; 
            _mapper = mapper;

        }


        public async Task<ResponseModel<Usuario>> BuscarUsuarioPorId(int usuarioId)
        {
            ResponseModel<Usuario> response = new ResponseModel<Usuario>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("select * from Usuarios where id = @Id", new {Id = usuarioId});
                
                    if (usuarioBanco == null)
                    {
                        response.Mensagem = "Nenhum Usuario localizado!";
                        response.Status = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }
                    response.dados = usuarioBanco;
                    response.Mensagem = "Usuario Localizado Com Sucesso!";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.Mensagem = "Ocorreu um erro no processo";
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
		}


        public async Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");
                    if (usuariosBanco.Count() == 0)
                    {
                        response.Mensagem = "Nenhum usuario Localizado!";
                        response.Status = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }
                    var usuarioMapeado = _mapper.Map<List<UsuarioListarDTO>>(usuariosBanco);
                    response.dados = usuarioMapeado;
                    response.Mensagem = "Usuários Localizados com sucesso!";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.Mensagem = "Ocorreu um erro no processo";
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
           
        }


        public async Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var cpfExists = await connection.ExecuteScalarAsync<bool>("select case when exists (select 1 from usuarios where cpf = @cpf) then 1 else 0 end",new { CPF = usuarioCriarDTO.CPF });
                    if (cpfExists)
                    {
                        response.Mensagem = "CPF já cadastrado no sistema.";
                        response.Status = System.Net.HttpStatusCode.Conflict;
                        return response;
                    }
                    var usuariosBanco = await connection.ExecuteAsync("insert into usuarios (nomecompleto, email, cpf, situacao) values (@nomecompleto, @email, @cpf, @situacao)",usuarioCriarDTO);
                    if (usuariosBanco == 0)
                    {
                        response.Mensagem = "Ocorreu um erro ao realizar o registro!";
                        response.Status = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }
                    var usuarios = await ListarUsuarios(connection);
                    var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
                    response.dados = usuariosMapeados;
                    response.Mensagem = "Usuário criado com sucesso.";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.Mensagem = "Ocorreu um erro no processo";
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }


        private static async Task<IEnumerable<Usuario>> ListarUsuarios(SqlConnection connection)
        {
            return await connection.QueryAsync<Usuario>("select * from Usuarios");
        }


        public async Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioListarDTO usuarioListarDTO)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usuariosBanco = await connection.ExecuteAsync("update Usuarios set NomeCompleto = @NomeCompleto,Email = @Email, situacao =@Situacao where id = @Id", usuarioListarDTO);
                    if (usuariosBanco == 0)
                    {
                        response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                        response.Status = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }
                    var usuarios = await ListarUsuarios(connection);
                    var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
                    response.dados = usuariosMapeados;
                    response.Mensagem = "Usuarios listados com sucesso!";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.Mensagem = "Ocorreu um erro no processo";
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
            
		}


        public async Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(int usuarioId)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usuarioBanco = await connection.ExecuteAsync("delete from Usuarios where id = @Id", new { Id = usuarioId });
                    if (usuarioBanco == 0)
                    {
                        response.Mensagem = "Não existe esse Usuario no Banco!";
                        response.Status = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }
                    var usuarios = await ListarUsuarios(connection);
                    var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
                    response.dados = usuariosMapeados;
                    response.Mensagem = "Usuario Listados com sucesso";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.Mensagem = "Ocorreu um erro no processo";
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
           
        
        }
    }
}

