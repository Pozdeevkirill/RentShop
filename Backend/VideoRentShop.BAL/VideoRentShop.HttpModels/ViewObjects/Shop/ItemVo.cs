namespace VideoRentShop.HttpModels.ViewObjects.Shop
{
	public class ItemVo : EntityVo
	{
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public List<FileVo> Files { get; set; }
    }
}
