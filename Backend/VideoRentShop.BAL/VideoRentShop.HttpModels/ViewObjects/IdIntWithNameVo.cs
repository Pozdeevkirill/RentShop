namespace VideoRentShop.HttpModels.ViewObjects
{
	public class IdIntWithNameVo
	{
		public IdIntWithNameVo(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
        public string Name { get; set; }
    }
}
