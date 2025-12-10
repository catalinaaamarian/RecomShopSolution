using System;
using System.Collections.Generic;

namespace RecomShop.WebMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }  

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
       

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
