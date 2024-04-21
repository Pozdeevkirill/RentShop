namespace VideoRentShop.HttpModels.Requests.Admin
{
    /// <summary>
    /// Добавиление картинки 
    /// </summary>
	public class AddFileAttachemntRequest : IBaseRequest
	{
        /// <summary>
        /// Название файла(без расширения)
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Название файла
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Тип файла
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public byte[] File { get; set; }
    }
}
