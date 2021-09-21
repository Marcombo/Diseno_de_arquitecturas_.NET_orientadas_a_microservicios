using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Ok.LSP
{
    public interface ICreateGenericRepository<T> where T : class
    {
        Task<string> AddAsync(T entity);//Retorna id de la entidad almacenada
    }
}
