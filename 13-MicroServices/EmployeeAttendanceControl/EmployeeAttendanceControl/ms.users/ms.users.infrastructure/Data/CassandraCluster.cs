using Cassandra;
using Microsoft.Extensions.Configuration;

namespace ms.users.infrastructure.Data
{
    public class CassandraCluster
    {
        public Cluster ConfiguredCluster { get; set; }

        public CassandraCluster(IConfiguration configuration)
        {
            var hostname = configuration.GetSection("DatabaseSettings:Hostname").Value;

            var port = configuration.GetSection("DatabaseSettings:Port").Value;

            ConfiguredCluster = Cluster.Builder().AddContactPoint(hostname)
                                                 .WithPort(int.Parse(port))
                                                 .Build();
        }
    }
}
