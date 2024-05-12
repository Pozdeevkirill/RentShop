namespace VideoRentShop.Models.Shop
{
	public class Baner : Entity
	{
        /// <summary>
        /// Название банера
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Активный ли банер(Отображаеться на гл.Странице)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Маркер удаленной сущности
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
