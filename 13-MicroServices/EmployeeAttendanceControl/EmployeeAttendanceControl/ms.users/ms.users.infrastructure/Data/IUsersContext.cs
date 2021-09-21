using System;
using Cassandra.Mapping;

namespace ms.users.infrastructure.Data
{
    public interface IUsersContext
    {
        IMapper GetMapper();
    }
}
