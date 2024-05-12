using VideoRentShop.Models.Shop.File;

namespace VideoRentShop.Models.Shop
{
    public class Banner : Entity
	{
		private Banner()
		{
		}

		public Banner(string name, bool isActive, FileAttachment file)
		{
            Name = name;
            Image = file;
            IsActive = isActive;
		}

		/// <summary>
		/// Название банера
		/// </summary>
		public string Name { get; set; }

        /// <summary>
        /// Активный ли банер(Отображаеться на гл.Странице)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Картинка банера
        /// </summary>
        public FileAttachment Image { get; set; }
    }
}
