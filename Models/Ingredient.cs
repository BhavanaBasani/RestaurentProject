namespace RestaurentProject.Models
{
    public class Ingredient
    {
        public int IngredientId{ get; set; }
        public string Name { get; set; }

        public ICollection<ProductIngredients> ProductIngredients { get; set; } //An ingredient can be in many products

    }
}