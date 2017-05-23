using ShoppingList.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.EntityFramework
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Set
        {
            get { return this._context.Set<T>(); }
        }

        public IQueryable<T> GetAllByQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public T FindByQuery(string query)
        {
            return _context.Set<T>().SqlQuery(query).FirstOrDefault();
        }

        public ICollection<T> FindAllByQuery(string query)
        {
            return _context.Set<T>().SqlQuery(query).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public T Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public List<T> AddRange(List<T> t)
        {
            _context.Set<T>().AddRange(t);
            _context.SaveChanges();
            return t;
        }

        public async Task<T> AddAsync(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            _context.SaveChanges();

            return updated;
        }

        public T MapperEntity(T entity, int key)
        {
            _context.Set<T>().Attach(entity);

            if (key > 0)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
                return entity;
            }
            else
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                return entity;
            }
        }

        public async Task<T> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                return null;

            await _context.SaveChangesAsync();

            return updated;
        }

        public T AddOrUpdate(T t, int key)
        {
            if (key > 0)
                return Update(t, key);

            return Add(t);
        }

        public async Task<T> AddOrUpdateAsync(T t, int key)
        {
            if (key > 0)
                return await UpdateAsync(t, key);

            return await AddAsync(t);
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            return await _context.SaveChangesAsync();
        }

        public int DeleteAll(ICollection<T> t)
        {
            _context.Set<T>().RemoveRange(t);
            return _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
