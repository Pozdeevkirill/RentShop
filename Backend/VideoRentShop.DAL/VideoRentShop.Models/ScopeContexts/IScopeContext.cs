namespace VideoRentShop.Models.ScopeContexts
{
    /// <summary>
    /// Интерфейс связи сущностей
    /// </summary>
    /// <typeparam name="T">Какая сущность</typeparam>
    /// <typeparam name="TTo">К какой сущности</typeparam>
    public interface IScopeContext<T,TTo>
        where T : Entity
        where TTo : Entity
    {
        /// <summary>
        /// Ид связи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Какая сущность
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// К какой сущности
        /// </summary>
        public TTo EntitTo { get; set; }
    }
}