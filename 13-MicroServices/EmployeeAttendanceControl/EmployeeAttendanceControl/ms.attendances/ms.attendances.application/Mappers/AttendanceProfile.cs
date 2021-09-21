using AutoMapper;
using ms.attendances.application.Request;
using ms.attendances.application.Responses;
using ms.attendances.domain.Entities;

namespace ms.attendances.application.Mappers
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<AttendanceRecord, AttendanceResponse>().ReverseMap();
            CreateMap<AttendanceRecord, CreateAttendanceRequest>().ReverseMap();
        }
    }
}
