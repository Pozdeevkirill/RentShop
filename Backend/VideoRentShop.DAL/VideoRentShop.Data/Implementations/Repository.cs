using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Models;

namespace VideoRentShop.Data.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly MainDbContext _context;

        public Repository(MainDbContext mainDbContext)
        {
            _context = mainDbContext ?? throw new ArgumentNullException(nameof(mainDbContext));
        }

        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public Query<TEntity> Query()
        {
            return new Query<TEntity>();
        }

        public Guid Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity.Id;
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public bool Any()
        {
            return _context.Set<TEntity>().Any();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).Count();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity? Get(Guid id)
        {
            return _context.Set<TEntity>().Find(new object[] { id });
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
                return _context.Set<TEntity>().AsNoTracking();
            else
                return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            if (asNoTracking)
                return _context.Set<TEntity>().Where(predicate).AsNoTracking();
            else
                return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = GetAll();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }

            return queryable;
        }

        public IList<TEntity> List()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IList<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

		public IList<TEntity> ListToPagin(int take, int skip)
		{
            return _context.Set<TEntity>().Skip(skip).Take(take).ToList();
		}

		public IList<TEntity> ListToPagin(int take, int skip, Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate).Skip(skip).Take(take).ToList();
		}

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
