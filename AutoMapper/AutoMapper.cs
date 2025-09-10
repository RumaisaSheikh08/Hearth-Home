using AutoMapper;
using StoreEcommerce.DTO;
using StoreEcommerce.Models;

namespace StoreEcommerce.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserRegisterDTO, Users>();
        }
    }
}
