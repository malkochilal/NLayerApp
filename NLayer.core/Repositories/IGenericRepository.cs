
using System.Linq.Expressions;


namespace NLayer.core.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        //productRepository.GetAll(x=>x.id>5).Tolist(); toList metodunu çağırdığık anda veritabanına sorgu atar.
        //IQueryable'da atılmaz.Bunlar memoryde birleştirilip tek bir seferde veritabanına gönderilir
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>>expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity); //update'ın async'si yok.add memorye data ekliyor.Uzun süren işlem olduğu için async var.
        void Remove(T entity);//async olmamasının nedeni uzun süren bir işlem olmadığı için
        void RemoveRange(IEnumerable<T> entities);
    }
}
