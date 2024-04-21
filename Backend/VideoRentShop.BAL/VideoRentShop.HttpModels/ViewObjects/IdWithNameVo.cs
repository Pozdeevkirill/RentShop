namespace VideoRentShop.HttpModels.ViewObjects
{
	public class IdWithNameVo
	{
		public IdWithNameVo(Guid id, string name)
		{
			Id = id;
			Name = name;
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
