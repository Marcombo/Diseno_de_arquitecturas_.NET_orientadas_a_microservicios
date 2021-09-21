using System;
using System.Text.Json;

namespace ms.rabbitmq.Events
{
    public class EmployeeCreatedEvent : RabbitMqEvent
    {
        public Guid EventId => Guid.NewGuid();

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string Serialize()=>JsonSerializer.Serialize(this);
        
    }
}
