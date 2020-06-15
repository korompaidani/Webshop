namespace WebshopApi.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string UploadTime { get; set; }
        public string Category { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
    }
}