using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Set { get; }
        IQueryable<T> GetAllByQuery();
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T Get(int id);
        Task<T> GetAsync(int id);

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T FindByQuery(string query);
        ICollection<T> FindAllByQuery(string query);

        T Add(T t);

        List<T> AddRange(List<T> t);

        Task<T> AddAsync(T t);

        T Update(T updated, int key);

        T MapperEntity(T updated, int key);

        Task<T> UpdateAsync(T updated, int key);

        T AddOrUpdate(T t, int key);
        Task<T> AddOrUpdateAsync(T t, int key);

        void Delete(T t);
        Task<int> DeleteAsync(T t);

        int Count();
        Task<int> CountAsync();

        int DeleteAll(ICollection<T> t);
    }
}
