namespace VideoRentShop.Models.Shop
{
    public class Item : Entity
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена на товар
        /// </summary>
        public List<Price>? Prices { get; set; }

        /// <summary>
        /// Активный товара(Находится на продаже)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Картинки к товару
        /// </summary>
        public List<ItemFile>? Files { get; set; }
    }
}
