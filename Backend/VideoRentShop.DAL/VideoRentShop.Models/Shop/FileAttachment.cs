namespace VideoRentShop.Models.Shop
{
    public abstract class FileAttachment : Entity
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Название файла + расширение
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
