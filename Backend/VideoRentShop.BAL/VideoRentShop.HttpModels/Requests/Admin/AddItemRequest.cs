namespace VideoRentShop.HttpModels.Requests.Admin
{
	/// <summary>
	/// Запрос на создание товара
	/// </summary>
	public class AddItemRequest : IBaseRequest
	{
		/// <summary>
		/// Название товара
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
        public string Description { get; set; }

		/// <summary>
		/// Активность
		/// </summary>
        public bool IsActive { get; set; }

        /// <summary>
		/// Цены на товар
		/// </summary>
		//public List<PriceRequest> Prices { get; set; }

    }

	public class PriceRequest : IBaseRequest
	{
        public string Time { get; set; }
        public double Price { get; set; }
    }
}
