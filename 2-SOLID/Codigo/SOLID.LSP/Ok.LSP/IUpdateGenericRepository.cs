using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Ok.LSP
{
    public interface IUpdateGenericRepository<T> where T : class
    {
        Task<int> UpdateAsync(T entity);//Retorna el numero de registros modificados
    }
}
