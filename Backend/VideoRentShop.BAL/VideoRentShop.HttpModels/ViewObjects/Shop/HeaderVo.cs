namespace VideoRentShop.HttpModels.ViewObjects.Shop
{
    public class HeaderVo
    {
        public Guid Id { get; set; }
        public string Label { get; set; }

        public string SubLabel { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public byte[]? BackgroundFile { get; set; }
    }
}
