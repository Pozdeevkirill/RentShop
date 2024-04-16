using System.ComponentModel;

namespace VideoRentShop.Common
{
	public static class EnumHelper
    {
		public static string GetEnumDescription(this Enum enumValue)
		{
			var field = enumValue.GetType().GetField(enumValue.ToString());
			if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
			{
				return attribute.Description;
			}
			throw new ArgumentException("Item not found.", nameof(enumValue));
		}

		public static Dictionary<int, string> GetEnumValues<TEnum>()
			where TEnum : Enum
		{
			Dictionary<int, string> result = new();

			foreach (var item in Enum.GetValues(typeof(TEnum)))
			{
				result.Add((int)item, GetEnumDescription((TEnum)item));
			}
			return result;
		}
	}
}
