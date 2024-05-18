namespace VideoRentShop.HttpModels.Requests.Admin
{
    /// <summary>
    /// Запрос редактировани заголовка
    /// </summary>
    /// TODO: Добавить сюда редактирование изображения
    public class EditHeaderRequest : IBaseRequest
    {
        /// <summary>
        /// Ид заголовка
        /// </summary>
        public Guid Id { get; set; }
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
    }
}
