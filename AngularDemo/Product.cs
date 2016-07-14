namespace AngularDemo
{
    public class Product
    {
        public bool CanPurchase { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool SoldOut { get; set; }
        public Image[] Images { get; set; }
        public Review[] Reviews { get; set; }
    }
}