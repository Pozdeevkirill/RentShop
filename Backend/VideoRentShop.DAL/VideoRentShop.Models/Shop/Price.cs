namespace VideoRentShop.Models.Shop
{
    public class Price : Entity
    {
        /// <summary>
        /// На какое время идет аренда
        /// </summary>
        /// TODO: Возможнос тоит переделать на отдельный объект, что бы было удобнее
        public string Time { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double PriceValue { get; set; }
    }
}
