using System;
using SOLID.LSP.Ok.LSP;
using SOLID.LSP.Violation.LSP;

namespace SOLID.LSP
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public void DeleteEntity<T>(IDeleteGenericRepository<T> deleteGenericRepository
                                  , string id) where T : class {
            deleteGenericRepository.DeleteAsync(id);
        }
    }
}
