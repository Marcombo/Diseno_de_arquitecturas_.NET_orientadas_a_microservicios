using System;
using AutoMapper;
using ms.attendances.domain.Entities;
using ms.attendances.infrastructure.MongoEntities;

namespace ms.attendances.infrastructure.Mappers
{
    public class AttendanceMongoProfile : Profile
    {
        public AttendanceMongoProfile() =>
            CreateMap<AttendanceMongo, AttendanceRecord>().ReverseMap();
    }
}
