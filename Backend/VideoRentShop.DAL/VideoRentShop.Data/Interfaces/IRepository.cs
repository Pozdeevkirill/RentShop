using System.Linq.Expressions;
using VideoRentShop.Models;

namespace VideoRentShop.Data.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для всех репозиториев
    /// </summary>
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        Guid Add(TEntity entity);

        /// <summary>
        /// Добавить несколько сущностей
        /// </summary>
        void AddRange(ICollection<TEntity> entities);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// Удалить несколько сущсностей
        /// </summary>
        void DeleteRange(ICollection<TEntity> entities);

        /// <summary>
        /// Обновить cущность
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <param name="asNoTracking">Сохранять ли полученные данные в КЕШ</param>
        IQueryable<TEntity> GetAll(bool asNoTracking = true);

        /// <summary>
        /// Получить список сущностей
        /// </summary>
        /// <param name="predicate">Функция сортировки</param>
        /// <param name="asNoTracking">Сохранять ли полученные данные в КЕШ</param>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);

        /// <summary>
        /// Получить сущность по ИДы
        /// </summary>
        /// <param name="id">ид сущности</param>
        TEntity? Get(Guid id);

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="predicate">Функция сортировки</param>
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);

		IList<TEntity> List();
		IList<TEntity> List(Expression<Func<TEntity, bool>> predicate);

		IList<TEntity> ListToPagin(int take, int skip);
        IList<TEntity> ListToPagin(int take, int skip, Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Полчить кол-во сущностей
		/// </summary>
		int Count();

        /// <summary>
        /// Получить кол-во сущностей с условием
        /// </summary>
        /// <param name="predicate">Условие сорртировки</param>
        int Count(Expression<Func<TEntity, bool>> predicate);
        bool Any();
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Получить все сущности, которые содержат...<br/>
        /// </summary>
        /// Думаю что запросов List вполне хватит
        /// Возможно удаляю позднее
        /// Примерный запрос: _repository.Where(x => x.ChildEntities != null);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
