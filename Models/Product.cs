using System.ComponentModel;

namespace RestaurentProject.Models
{
    public class Product
    {
        public int Productid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int stock { get; set; }

        public int Categoryid { get; set; }

        public Category? Category { get; set; }//A product belongs to a category

        public ICollection <OrderItem> OrderItems { get; set; } //A product can be in many orders
        public ICollection<ProductIngredients>ProductIngredients { get; set; }//A product can have many ingredients



}
}