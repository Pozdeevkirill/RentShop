namespace VideoRentShop.HttpModels.Requests.Admin
{
    /// <summary>
    /// Запрос на редактирование товара
    /// </summary>
    /// TODO: Добавить редактирование картинок
    public class EditItemRequest : IBaseRequest
    {
        /// <summary>
        /// Ид товара
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
		/// Название товара
		/// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
		/// Цены на товар за смену
		/// </summary>
		public decimal Price { get; set; }
    }
}
