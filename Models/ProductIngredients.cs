namespace RestaurentProject.Models
{
    public class ProductIngredients
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } //A product can have many ingredients

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } //An ingredient can be in many products 
    }
}