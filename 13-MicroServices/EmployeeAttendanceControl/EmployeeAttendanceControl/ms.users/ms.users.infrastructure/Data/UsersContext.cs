using Cassandra.Mapping;
using Microsoft.Extensions.Configuration;
using ms.users.infrastructure.Mappings;

namespace ms.users.infrastructure.Data
{
    public class UsersContext : IUsersContext
    {
        private IMapper _usersMapper;
        private CassandraUserMapping _cassandraUserMapping;

        public UsersContext(CassandraCluster cassandraCluster,
                            CassandraUserMapping cassandraUserMapping,
                            IConfiguration configuration)
        {
            var keyspace = configuration.GetSection("DatabaseSettings:Keyspace").Value;
            var session = cassandraCluster.ConfiguredCluster.Connect(keyspace);

            _usersMapper = new Mapper(session);

            _cassandraUserMapping = cassandraUserMapping;
        }

        public IMapper GetMapper() => _usersMapper;
    }
}
