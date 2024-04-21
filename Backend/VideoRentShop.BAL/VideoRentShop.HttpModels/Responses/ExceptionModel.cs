namespace VideoRentShop.HttpModels.Responses
{
	/// <summary>
	/// Базовая модель ошибки
	/// </summary>
	public class ExceptionModel
	{
		/// <summary>
		/// Статус
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// Заголовок
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Сообщение
		/// </summary>
        public string Message { get; set; }

		/// <summary>
		/// Дополнительная информация
		/// </summary>
        public string Detail { get; set; }

		/// <summary>
		/// Дополнительные данные
		/// </summary>
        public Dictionary<string, object> Data { get; set; }
    }
}
