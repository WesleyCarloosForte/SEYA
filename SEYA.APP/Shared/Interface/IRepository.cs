using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.APP.Shared.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update (T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Func<T, bool> where);

    }
}
