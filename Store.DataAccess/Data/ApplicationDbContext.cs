using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyProduct> CompanyProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "CIVIL", DisplayOrder = 1 },
                new Category { Id = 2, Name = "ENVT", DisplayOrder = 2 },
                new Category { Id = 3, Name = "CST", DisplayOrder = 3 },
                new Category { Id = 4, Name = "FOOD", DisplayOrder = 4 },
                new Category { Id = 5, Name = "AIDT", DisplayOrder = 5 }
            );

            // Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Hoque", StreetAddress = "5 Erie Court", City = "Dhaka", PostalCode = "64800-000", PhoneNumber = "362-555-3461" },
                new Company { Id = 2, Name = "Technical", StreetAddress = "592 Porter Way", City = "Dhaka", PostalCode = "477047", PhoneNumber = "725-831-6046" },
                new Company { Id = 3, Name = "Global Books", StreetAddress = "123 Mirpur Road", City = "Dhaka", PostalCode = "1216", PhoneNumber = "01711-234567" },
                new Company { Id = 4, Name = "Poly Publishers", StreetAddress = "House 45, Road 12", City = "Dhaka", PostalCode = "1207", PhoneNumber = "01822-345678" },
                new Company { Id = 5, Name = "Eco Press", StreetAddress = "88 Green Road", City = "Dhaka", PostalCode = "1205", PhoneNumber = "01933-456789" },
                new Company { Id = 6, Name = "FoodTech Books", StreetAddress = "56 Banani", City = "Dhaka", PostalCode = "1213", PhoneNumber = "01644-567890" },
                new Company { Id = 7, Name = "AI Vision", StreetAddress = "Plot 10, Gulshan", City = "Dhaka", PostalCode = "1212", PhoneNumber = "01555-678901" }
            );

            // Products (existing 1–15 + new 16–30)
            modelBuilder.Entity<Product>().HasData(
                // === Existing 1–15 (kept as-is) ===
                new Product { Id = 1, Title = "1st Semester Book", Author = "Akash", Description = "All Book Aviable", ISBN = "SWD9999001", CategoryID = 1, ImageURL = "" },
                new Product { Id = 2, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Description = "A comprehensive guide to algorithms and data structures.", ISBN = "9780262033848", CategoryID = 3, ImageURL = "" },
                new Product { Id = 3, Title = "Clean Code", Author = "Robert C. Martin", Description = "Best practices for writing readable, maintainable code.", ISBN = "9780132350884", CategoryID = 3, ImageURL = "" },
                new Product { Id = 4, Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", Description = "Timeless advice for becoming a better developer.", ISBN = "9780201616224", CategoryID = 3, ImageURL = "" },
                new Product { Id = 5, Title = "2nd Semester Physics", Author = "Dr. Sarah Johnson", Description = "Complete physics textbook for semester 2.", ISBN = "PHY2023002", CategoryID = 1, ImageURL = "" },
                new Product { Id = 6, Title = "Organic Chemistry Made Simple", Author = "John E. McMurry", Description = "Clear explanations of organic reactions.", ISBN = "9781305780170", CategoryID = 1, ImageURL = "" },
                new Product { Id = 7, Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "Classic novel exploring racial injustice.", ISBN = "9780446310789", CategoryID = 2, ImageURL = "" },
                new Product { Id = 8, Title = "1984", Author = "George Orwell", Description = "Dystopian masterpiece about totalitarianism.", ISBN = "9780451524935", CategoryID = 2, ImageURL = "" },
                new Product { Id = 9, Title = "Design Patterns", Author = "Erich Gamma et al.", Description = "Foundational book on reusable design patterns.", ISBN = "9780201633610", CategoryID = 3, ImageURL = "" },
                new Product { Id = 10, Title = "Calculus: Early Transcendentals", Author = "James Stewart", Description = "Thorough calculus textbook.", ISBN = "9781285741550", CategoryID = 1, ImageURL = "" },
                new Product { Id = 11, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "Iconic American novel about the American Dream.", ISBN = "9780743273565", CategoryID = 2, ImageURL = "" },
                new Product { Id = 12, Title = "ASP.NET Core in Action", Author = "Andrew Lock", Description = "Practical guide to ASP.NET Core.", ISBN = "9781617298301", CategoryID = 3, ImageURL = "" },
                new Product { Id = 13, Title = "Biology for Beginners", Author = "Dr. Emily Chen", Description = "Introductory biology text.", ISBN = "BIO1014001", CategoryID = 1, ImageURL = "" },
                new Product { Id = 14, Title = "Pride and Prejudice", Author = "Jane Austen", Description = "Witty romantic novel.", ISBN = "9780141439518", CategoryID = 2, ImageURL = "" },
                new Product { Id = 15, Title = "Data Structures and Algorithms in C#", Author = "Michael McMillan", Description = "Hands-on implementation in C#.", ISBN = "9780470383261", CategoryID = 3, ImageURL = "" },

                // === New Products 16–30 ===
                new Product { Id = 16, Title = "Structural Analysis", Author = "R.C. Hibbeler", Description = "Fundamental concepts of structural analysis for civil engineers.", ISBN = "9780133942842", CategoryID = 1, ImageURL = "" },
                new Product { Id = 17, Title = "Environmental Engineering", Author = "Howard S. Peavy", Description = "Comprehensive guide to water and wastewater treatment.", ISBN = "9780070495395", CategoryID = 2, ImageURL = "" },
                new Product { Id = 18, Title = "Database System Concepts", Author = "Abraham Silberschatz", Description = "Core concepts of database design and management.", ISBN = "9780078022159", CategoryID = 3, ImageURL = "" },
                new Product { Id = 19, Title = "Food Microbiology", Author = "William C. Frazier", Description = "Study of microorganisms in food production and safety.", ISBN = "9780070667181", CategoryID = 4, ImageURL = "" },
                new Product { Id = 20, Title = "Artificial Intelligence: A Modern Approach", Author = "Stuart Russell & Peter Norvig", Description = "The standard AI textbook used worldwide.", ISBN = "9780134610993", CategoryID = 5, ImageURL = "" },
                new Product { Id = 21, Title = "Geotechnical Engineering", Author = "Braja M. Das", Description = "Principles of soil mechanics and foundation design.", ISBN = "9781337630931", CategoryID = 1, ImageURL = "" },
                new Product { Id = 22, Title = "Wastewater Engineering", Author = "Metcalf & Eddy", Description = "Treatment and reuse of wastewater.", ISBN = "9780073401188", CategoryID = 2, ImageURL = "" },
                new Product { Id = 23, Title = "Operating System Concepts", Author = "Abraham Silberschatz", Description = "Essential operating systems theory and practice.", ISBN = "9781119456339", CategoryID = 3, ImageURL = "" },
                new Product { Id = 24, Title = "Food Processing Technology", Author = "P.J. Fellows", Description = "Principles and practices in food processing.", ISBN = "9780081019078", CategoryID = 4, ImageURL = "" },
                new Product { Id = 25, Title = "Deep Learning", Author = "Ian Goodfellow", Description = "Comprehensive introduction to deep learning.", ISBN = "9780262035613", CategoryID = 5, ImageURL = "" },
                new Product { Id = 26, Title = "Transportation Engineering", Author = "C. Jotin Khisty", Description = "Planning and design of transportation systems.", ISBN = "9780136135739", CategoryID = 1, ImageURL = "" },
                new Product { Id = 27, Title = "Air Pollution Control", Author = "C. David Cooper", Description = "Engineering solutions for air quality management.", ISBN = "9781577666783", CategoryID = 2, ImageURL = "" },
                new Product { Id = 28, Title = "Computer Networks", Author = "Andrew S. Tanenbaum", Description = "Top-down approach to networking.", ISBN = "9780132126953", CategoryID = 3, ImageURL = "" },
                new Product { Id = 29, Title = "Nutrition and Dietetics", Author = "Shubhangini A. Joshi", Description = "Fundamentals of human nutrition.", ISBN = "9780070146334", CategoryID = 4, ImageURL = "" },
                new Product { Id = 30, Title = "Machine Learning Yearning", Author = "Andrew Ng", Description = "Practical advice for building ML systems.", ISBN = "MLY2021001", CategoryID = 5, ImageURL = "" }
            );

            // CompanyProduct pricing (varied per company)
            modelBuilder.Entity<CompanyProduct>().HasData(
                // Product 1
                new CompanyProduct { CompanyId = 1, ProductId = 1, ListPrice = 100, Price = 90 },
                new CompanyProduct { CompanyId = 2, ProductId = 1, ListPrice = 110, Price = 100 },
                new CompanyProduct { CompanyId = 3, ProductId = 1, ListPrice = 95, Price = 85 },

                // Product 2
                new CompanyProduct { CompanyId = 1, ProductId = 2, ListPrice = 50, Price = 45 },
                new CompanyProduct { CompanyId = 2, ProductId = 2, ListPrice = 60, Price = 55 },
                new CompanyProduct { CompanyId = 4, ProductId = 2, ListPrice = 55, Price = 50 },

                // Product 3–30 (sample pricing - you can expand further)
                new CompanyProduct { CompanyId = 3, ProductId = 3, ListPrice = 80, Price = 70 },
                new CompanyProduct { CompanyId = 5, ProductId = 3, ListPrice = 85, Price = 75 },
                new CompanyProduct { CompanyId = 1, ProductId = 16, ListPrice = 120, Price = 110 },
                new CompanyProduct { CompanyId = 4, ProductId = 16, ListPrice = 115, Price = 105 },
                new CompanyProduct { CompanyId = 2, ProductId = 17, ListPrice = 130, Price = 120 },
                new CompanyProduct { CompanyId = 5, ProductId = 17, ListPrice = 125, Price = 115 },
                new CompanyProduct { CompanyId = 6, ProductId = 19, ListPrice = 90, Price = 80 },
                new CompanyProduct { CompanyId = 7, ProductId = 20, ListPrice = 200, Price = 180 },
                new CompanyProduct { CompanyId = 3, ProductId = 25, ListPrice = 220, Price = 200 }
            // Add as many as you like...
            );

            // Many-to-many configuration
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Companies)
                .WithMany(c => c.Products)
                .UsingEntity<CompanyProduct>(
                    j => j.HasKey(cp => new { cp.CompanyId, cp.ProductId }));
        }
    }
}
