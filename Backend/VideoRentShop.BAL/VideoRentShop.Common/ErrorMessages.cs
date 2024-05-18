namespace VideoRentShop.Common
{
    /// <summary>
    /// Класс, который содержит в себе частые ошибки, возвращаемые клиенту
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Запрос не может быть пустым.
        /// </summary>
        public static string RequestEmptyError = "Запрос не может быть пустым.";

        /// <summary>
        /// Сущность с таким Id не найдена
        /// </summary>
        public static string NotFoundByIdError = "Сущность с таким Id не найдена.";

        /// <summary>
        /// Id не может быть пустым
        /// </summary>
        public static string IdCantBeNullError = "Id не может быть пустым";

        /// <summary>
        /// Не все обязательные поля заполнены или заполнены не корректно.
        /// </summary>
        public static string RequiredFieldsError = "Не все обязательные поля заполнены или заполнены не корректно.";

        /// <summary>
        /// Сущность не изменена.
        /// </summary>
        public static string EntityNotChangedError = "Сущность не изменена.";
    }
}
