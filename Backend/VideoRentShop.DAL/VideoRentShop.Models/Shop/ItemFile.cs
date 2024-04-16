namespace VideoRentShop.Models.Shop
{
	/// <summary>
	/// Файл предмета
	/// </summary>
	public class ItemFile : FileAttachment
	{
		/// <summary>
		/// Ид предмета
		/// </summary>
        public Guid ItemId { get; set; }
    }
}
