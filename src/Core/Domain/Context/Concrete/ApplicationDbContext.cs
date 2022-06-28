using BasicECommerce.DAL.Context.Abstract;
using BasicECommerce.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerce.DAL.Context.Concrete
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.Migrate(); //.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDBContext, EF6Console.Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IEnumerable<User> users = new List<User>()
                {
                    new User {Email = "secevit", UserName = "secevit", Name = "Sadettin", Lastname = "Ecevit"},
                    new User {Email = "ecevit", UserName = "ecevit", Name = "Sadettin", Lastname = "Ecevit"},
                    new User {Email = "sadettin", UserName = "sadettin", Name = "Sadettin", Lastname = "Ecevit"}
                };

            IEnumerable<Brand> brands = new List<Brand>()
                {
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Toyota" },
                    new Brand { Name = "Microsoft" }
                };

            IEnumerable<Color> colors = new List<Color>()
                {
                    new Color { Name = "None" },
                    new Color { Name = "Green" },
                    new Color { Name = "Blue" },
                    new Color { Name = "Red" }
                };

            IEnumerable<Category> categories = new List<Category>()
                {
                new Category { Name = "Mobile Phone" },
                new Category { Name = "Computer" },
                new Category { Name = "Car" },
                new Category { Name = "Software" }
                };

            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Brand>().HasData(brands);

            modelBuilder.Entity<Category>().HasData(categories);

            modelBuilder.Entity<Color>().HasData(colors);

            //IEnumerable<Product> products = new List<Product>()
            //    {
            //        new Product
            //        {
            //            Name = "Iphone 11",
            //            Brand = brands.FirstOrDefault(x=>x.Name == "Apple"),
            //            Category = categories.FirstOrDefault(x=>x.Name == "Mobile Phone"),
            //            Color = colors.FirstOrDefault(x=>x.Name == "Green"),
            //            Price = 15000.00m,
            //            Feature = "128 GB, etc.",
            //            Explanation = "Most popular mobile phone."
            //        },
            //        new Product
            //        {
            //            Name = "Windows 10 EOM Lisance",
            //            Brand = brands.FirstOrDefault(x=>x.Name == "Microsoft"),
            //            Category = categories.FirstOrDefault(x=>x.Name == "Software"),
            //            Color = colors.FirstOrDefault(x=>x.Name == "None"),
            //            Price = 500.00m,
            //            Feature = "Pro Product",
            //            Explanation = "You can use only one computer."
            //        },
            //        new Product
            //        {
            //            Name = "Toyota Hybrid",
            //            Brand = brands.FirstOrDefault(x=>x.Name == "Toyota"),
            //            Category = categories.FirstOrDefault(x=>x.Name == "Car"),
            //            Color = colors.FirstOrDefault(x=>x.Name == "Red"),
            //            Price = 550000.00m,
            //            Feature = "Hybrid Motor",
            //            Explanation = "You can take a test drive."
            //        },
            //        new Product
            //        {
            //            Name = "Galaxy 5",
            //            Brand = brands.FirstOrDefault(x=>x.Name == "Samsung"),
            //            Category = categories.FirstOrDefault(x=>x.Name == "Mobile Phone"),
            //            Color = colors.FirstOrDefault(x=>x.Name == "Blue"),
            //            Price = 5000.00m,
            //            Feature = "32 GB, etc.",
            //            Explanation = "It is a product of show."
            //        }
            //    };

            //modelBuilder.Entity<Product>().HasData(products);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }
    }
}
