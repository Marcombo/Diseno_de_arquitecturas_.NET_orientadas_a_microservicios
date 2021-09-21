using System;
using MongoDB.Driver;
using ms.attendances.infrastructure.MongoEntities;

namespace ms.attendances.infrastructure.Data
{
    public interface IAttendanceContext {
        IMongoCollection<AttendanceMongo> AttendanceCollection { get; }
    }
}
