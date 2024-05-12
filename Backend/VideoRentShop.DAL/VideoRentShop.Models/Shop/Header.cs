using VideoRentShop.Models.Shop.File;

namespace VideoRentShop.Models.Shop
{
    /// <summary>
    /// Объект описания header главной страницы
    /// </summary>
	public class Header : Entity
	{
		public Header(string label, string subLabel, string description, bool isActive, FileAttachment? backgroundImage)
		{
			Label = label;
			SubLabel = subLabel;
			Description = description;
			IsActive = isActive;
			BackgroundImage = backgroundImage;
		}

		public Header(string label, string subLabel, string description, bool isActive)
		{
			Label = label;
			SubLabel = subLabel;
			Description = description;
			IsActive = isActive;
		}

		/// <summary>
		/// Самый большой текст
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Текст поменьше, над Label
		/// </summary>
		/// (Ну а как его еще назвать ;D)
		public string SubLabel { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Активный ли header
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// Картинка заднего фона
        /// </summary>
        /// Если пусто, то будет стандартная картинка
        public FileAttachment? BackgroundImage { get; set; }

		public void Enable()
		{
			IsActive = true;
		}

		public void Disable()
		{
			IsActive = false;
		}
    }
}
