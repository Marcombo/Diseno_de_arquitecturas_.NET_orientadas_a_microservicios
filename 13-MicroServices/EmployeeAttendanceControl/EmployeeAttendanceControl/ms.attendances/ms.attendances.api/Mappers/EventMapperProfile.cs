using AutoMapper;
using ms.attendances.application.Request;
using ms.rabbitmq.Events;

namespace ms.attendances.api.Mappers
{
    public class EventMapperProfile : Profile
    {
        public EventMapperProfile()=>
            CreateMap<CreateAttendanceRequest, AttendanceStateChangedEvent>().ReverseMap();   
    }
}
