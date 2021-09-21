using AutoMapper;
using ms.users.application.Responses;
using ms.users.domain.Entities;

namespace ms.users.application.Mappers
{
    public class UsersMapperProfile : Profile
    {
        public UsersMapperProfile() => CreateMap<User, UserResponse>().ReverseMap();
    }
}
