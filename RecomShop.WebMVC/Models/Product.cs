namespace RecomShop.WebMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public float Rating { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
