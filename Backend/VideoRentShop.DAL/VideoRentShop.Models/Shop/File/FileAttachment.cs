namespace VideoRentShop.Models.Shop.File
{
    public class FileAttachment : Entity
    {
        public FileAttachment(string fileName, string systemName, string mimeType)
        {
            FileName = fileName;
            SystemName = systemName;
            MimeType = mimeType;
        }

        public FileAttachment(Guid entityId, string fileName, string systemName, string mimeType)
        {
            EntityId = entityId;
            FileName = fileName;
            SystemName = systemName;
            MimeType = mimeType;
        }

        /// <summary>
        /// Ид сущности которой принадлежит файл
        /// </summary>
        public Guid EntityId { get; set; }

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
