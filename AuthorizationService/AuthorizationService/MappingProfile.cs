using Authorization.Domain.DataTransferObject;
using Authorization.Domain.Models;
using AutoMapper;

namespace AuthorizationService
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RegisterAccountDto, Account>();
            CreateMap<LoginAccountDto, Account>();
        }
    }
}
