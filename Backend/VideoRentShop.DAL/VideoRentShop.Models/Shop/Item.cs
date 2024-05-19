using VideoRentShop.Models.Shop.File;

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
        /// Цена на товар за смену
        /// </summary>
        public decimal Price { get; set; } 

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

        public List<Order> Orders { get; set; }
    }
}
