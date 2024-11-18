
using AutoMapper;
using PROJETO_PAN.DTO;
using PROJETO_PAN.Models;

namespace PROJETO_PAN.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper() {

			CreateMap<Usuario, UsuarioListarDTO>();

		}

    }
}
