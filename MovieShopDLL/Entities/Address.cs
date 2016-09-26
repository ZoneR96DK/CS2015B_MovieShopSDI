namespace MovieShopDLL.Entities
{
    public class Address : AbstractEntity
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
    }
}