
namespace VideoRentShop.Models.Shop.File
{
    /// <summary>
    /// Файл предмета
    /// </summary>
    public class ItemFile : FileAttachment
    {
        public ItemFile(Guid entityId, string fileName, string systemName, string mimeType) 
            : base(entityId, fileName, systemName, mimeType)
        {
        }

        /// <summary>
        /// Указатель на основкую картинку
        /// </summary>
        public bool IsMainFile { get; set; }
    }
}
