namespace VideoRentShop.HttpModels.ViewObjects
{
	public class FileVo
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

		/// <summary>
		/// Указательна главный файл
		/// </summary>
        public bool IsMainFile { get; set; }
    }
}
