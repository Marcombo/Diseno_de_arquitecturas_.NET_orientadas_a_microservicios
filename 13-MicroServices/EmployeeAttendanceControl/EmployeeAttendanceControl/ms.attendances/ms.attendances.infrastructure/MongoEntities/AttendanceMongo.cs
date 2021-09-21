using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ms.attendances.infrastructure.MongoEntities
{
    public class AttendanceMongo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }
        public string Notes { get; set; }
    }
}
