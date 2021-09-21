using System;
using System.Data;

namespace ms.employees.infrastructure.Data
{
    public interface IDapperContext
    {
        IDbConnection Connection { get; }

        T Transaction<T>(Func<IDbTransaction, T> query);

        IDbTransaction BeginTransaction();
        
        void Commit();

        void Rollback();

        void Dispose();
    }
}
