namespace VideoRentShop.Models
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// ИД сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Признак удаленной сущности
        /// </summary>
        public bool IsDeleted { get;  protected set; } 


        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Delete()
        {
            if (IsDeleted) throw new Exception("Ошибка. Сущность уже удалена!");

            IsDeleted = true;
        }
    }
}
