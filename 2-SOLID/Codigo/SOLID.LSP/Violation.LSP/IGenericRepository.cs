using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Violation.LSP
{

    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetByIdAsync(string id);//Retorna entidad por id

        Task<IReadOnlyList<T>> GetAllAsync();//Retorna lista de entidades

        Task<string> AddAsync(T entity);//Retorna id de la entidad almacenada

        Task<int> UpdateAsync(T entity);//Retorna el numero de registros modificados

        Task<int> DeleteAsync(string id);//Retorna el numero de registros eliminados

    }
}
