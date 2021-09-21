using System;
using System.Text.Json;

namespace ms.rabbitmq.Events
{
    public class AttendanceStateChangedEvent : RabbitMqEvent
    {
        public Guid EventId => Guid.NewGuid();

        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }
        public string Notes { get; set; }

        public string Serialize() => JsonSerializer.Serialize(this);
    }
}
