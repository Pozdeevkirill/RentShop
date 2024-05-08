using System.Linq.Expressions;
using VideoRentShop.Models;

namespace VideoRentShop.Data
{
    public class Query<TEntity>
        where TEntity : Entity
    {
        private readonly MainDbContext _mainDbContext;
        public Query(MainDbContext context)
        {
            _mainDbContext = context;

            ConditionList = new();
            JoinList = new();
        }

        public List<Expression<Func<TEntity, bool>>> ConditionList { get; }
        public List<Expression<Func<TEntity, object>>> JoinList { get; }

        public Query<TEntity> SetCondition(Expression<Func<TEntity, bool>> condition)
        {
            ConditionList.Add(condition);
            return this;
        }

        public Query<TEntity> AddJoin(Expression<Func<TEntity, object>> join)
        {
            JoinList.Add(join);
            return this;
        }
    }
}
