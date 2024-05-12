namespace VideoRentShop.HttpModels.Requests.Public
{
    /// <summary>
    /// Запрос на создание объекта Header
    /// </summary>
	public class CreateHeaderRequest : IBaseRequest
	{
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Подзаголовок
        /// </summary>
        public string SubLabel { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Активный по умолчанию
        /// </summary>
        public bool IsActive { get; set; }
    }
}
