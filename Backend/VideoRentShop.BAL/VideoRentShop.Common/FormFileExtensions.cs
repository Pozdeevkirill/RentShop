using Microsoft.AspNetCore.Http;

namespace VideoRentShop.Common
{
	public static class FormFileExtensions
	{
		public static async Task<byte[]> GetBytes(this IFormFile formFile)
		{
			await using var memoryStream = new MemoryStream();
			await formFile.CopyToAsync(memoryStream);
			return memoryStream.ToArray();
		}

		public static string GetFriendlyName(this IFormFile formFile)
		{
			return formFile.FileName.Substring(0, formFile.FileName.Length - Path.GetExtension(formFile.FileName).Length);
		} 
	}
}
