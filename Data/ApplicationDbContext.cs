using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurentProject.Models;

namespace RestaurentProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredients> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configure the many-to-many relationship between Product and Ingredient
            builder.Entity<ProductIngredients>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });
            builder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            builder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients);

                //seed data
            builder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Appetizer" },
            new Category { CategoryId = 2, Name = "Entree" },
            new Category { CategoryId = 3, Name = "Side Dish" },
            new Category { CategoryId = 4, Name = "Dessert" },
            new Category { CategoryId = 5, Name = "Beverage" }
            );
            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" },
                new Ingredient { IngredientId = 2, Name = "Chicken" },
                new Ingredient { IngredientId = 3, Name = "fish" },
                new Ingredient { IngredientId = 4, Name = "tortilla" },
                new Ingredient { IngredientId = 5, Name = "lettuce" },
                new Ingredient { IngredientId = 6, Name = "tomato" }
                );
            builder.Entity<Product>().HasData(
                new Product { Productid = 1, Name = "Beef Tacos", Description = "Delicious tacos with beef", Price = 10.99m, stock = 100, Categoryid = 2 },
                new Product { Productid = 2, Name = "Chicken Taco", Description = "Healthy chicken Taco", Price = 8.99m, stock = 50, Categoryid = 2 },
                new Product { Productid = 3, Name = "Fish Tacos", Description = "Tasty fish tacos", Price = 12.99m, stock = 75, Categoryid = 2 }
            );

            builder.Entity<ProductIngredients>().HasData(  
                new ProductIngredients { ProductId = 1, IngredientId = 1 }, // Beef Tacos - Beef
                new ProductIngredients { ProductId = 1, IngredientId = 4 }, // Beef Tacos - Tortilla
                new ProductIngredients { ProductId = 1, IngredientId = 5 }, // Beef Tacos - Lettuce
                new ProductIngredients { ProductId = 1, IngredientId = 6 }, // Beef Tacos - Tomato
                new ProductIngredients { ProductId = 2, IngredientId = 2 }, // Chicken Taco - Chicken
                new ProductIngredients { ProductId = 2, IngredientId = 4 }, // Chicken Taco - Tortilla
                new ProductIngredients { ProductId = 2, IngredientId = 5 }, // Chicken Taco - Lettuce
                new ProductIngredients { ProductId = 2, IngredientId = 6 }, // Chicken Taco - Tomato
                new ProductIngredients { ProductId = 3, IngredientId = 3 }, // Fish Tacos - Fish
                new ProductIngredients { ProductId = 3, IngredientId = 4 }, // Fish Tacos - Tortilla
                new ProductIngredients { ProductId = 3, IngredientId = 5 },
                new ProductIngredients { ProductId = 3, IngredientId = 6 }
            );
        }


    }


}
