using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Ok.LSP
{
    public interface IReadGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);//Retorna entidad por id

        Task<IReadOnlyList<T>> GetAllAsync();//Retorna lista de entidades
    }
}
