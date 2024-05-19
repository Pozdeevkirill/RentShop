using VideoRentShop.Models.Enums;

namespace VideoRentShop.Models.Shop
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Общая цена
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Финальная цена (с учетом скидок)
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// Оплачено
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Карзина
        /// </summary>
        public IEnumerable<Item> Cart { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status{ get; set; }
    }
}
