using Cassandra.Mapping;
using ms.users.domain.Entities;

namespace ms.users.infrastructure.Mappings
{
    public class CassandraUserMapping : Cassandra.Mapping.Mappings
    {
        public CassandraUserMapping()
        {
            For<User>().TableName("User").PartitionKey(u => u.UserName)
                       .Column(c => c.UserName, cc => cc.WithName("user_username"))
                       .Column(c => c.Password, cc => cc.WithName("user_password"))
                       .Column(c => c.Role,     cc => cc.WithName("user_role"));

            MappingConfiguration.Global.Define(this);
        }
    }
}
