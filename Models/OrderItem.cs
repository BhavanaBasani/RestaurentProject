namespace RestaurentProject.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderID { get; set; }
        public Order? OrderId { get; set; }

        public int ProductId { get; set; }

        public Product? Productid { get; set; }

        public int quantity { get; set; }
        public decimal Price { get; set; }
    }
}