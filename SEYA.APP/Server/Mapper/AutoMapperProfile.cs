using AutoMapper;
using SEYA.APP.Shared;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.Server.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

        }

    }
}
