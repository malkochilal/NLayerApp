using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.core.Services
{
   public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        //productRepository.GetAll(x=>x.id>5).Tolist(); toList metodunu çağırdığık anda veritabanına sorgu atar.
        //IQueryable'da atılmaz.Bunlar memoryde birleştirilip tek bir seferde veritabanına gönderilir
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
       Task UpdateAsync(T entity); 
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
 