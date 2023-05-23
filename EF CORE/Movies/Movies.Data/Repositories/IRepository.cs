using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public interface IRepository<T>
    {
        //task = void 'in karşılığıdır
        Task CreateAsync(T entity); //asenkron olanlar isimlerinde belirtilir
        //void Create(T entity);//senkron
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

    }
}
