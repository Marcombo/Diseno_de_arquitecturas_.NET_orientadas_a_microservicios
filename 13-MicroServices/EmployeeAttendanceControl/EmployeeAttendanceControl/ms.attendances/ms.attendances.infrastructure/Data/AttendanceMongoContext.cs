using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ms.attendances.infrastructure.MongoEntities;

namespace ms.attendances.infrastructure.Data
{
    public class AttendanceMongoContext:IAttendanceContext
    {
        private readonly IConfiguration _configuration;
        private IMongoDatabase _mongoDatabase;

        public IMongoCollection<AttendanceMongo> AttendanceCollection =>
            _mongoDatabase.GetCollection<AttendanceMongo>(_configuration.GetConnectionString("Attendance:Collection"));

        public AttendanceMongoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoDatabase = new MongoClient(String.Concat(
                                                "mongodb://", configuration.GetConnectionString("Attendance:HostName"),
                                                ":", configuration.GetConnectionString("Attendance:Port"))
                                            ).GetDatabase(configuration.GetConnectionString("Attendance:DataBase"));
        }        
    }
}
