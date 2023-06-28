using AutoMapper;
using SEYA.APP.Shared.DTO.Cliente;
using SEYA.APP.Shared.DTO.Deuda;
using SEYA.APP.Shared.DTO.Funcionario;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Deuda, DeudaCreateDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioCreateDTO>().ReverseMap();
        }

    }
}
