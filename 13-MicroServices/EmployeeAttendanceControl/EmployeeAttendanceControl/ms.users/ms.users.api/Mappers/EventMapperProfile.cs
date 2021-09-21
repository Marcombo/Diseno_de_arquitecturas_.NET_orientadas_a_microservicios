using AutoMapper;
using ms.rabbitmq.Events;
using ms.users.application.Commands;

namespace ms.users.api.Mappers
{
    public class EventMapperProfile : Profile
    {
        public EventMapperProfile()=>
            CreateMap<CreateUserAccountCommand, EmployeeCreatedEvent>().ReverseMap();
    }
}
