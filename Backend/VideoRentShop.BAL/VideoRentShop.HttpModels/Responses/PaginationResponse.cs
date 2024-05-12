namespace VideoRentShop.HttpModels.Responses
{
    /// <summary>
    /// Ответ пагинацией
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public class PaginationResponse<T> : IBaseResponse
    {
        public PaginationResponse(List<T>? data, int countAll)
        {
            Data = data;
            CountAll = countAll;
        }

        /// <summary>
        /// Результат запроса
        /// </summary>
        public List<T>? Data { get; set; }

        /// <summary>
        /// Обзее кол-во элементов
        /// </summary>
        public int CountAll { get; set; }
    }
}
