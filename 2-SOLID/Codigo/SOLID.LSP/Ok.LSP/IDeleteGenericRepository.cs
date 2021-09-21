using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Ok.LSP
{
    public interface IDeleteGenericRepository<T> where T : class
    {
        Task<int> DeleteAsync(string id);//Retorna el numero de registros eliminados
    }
}
