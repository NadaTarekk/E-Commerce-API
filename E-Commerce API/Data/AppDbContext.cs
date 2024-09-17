using E_Commerce_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Commerce_API.Models.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            modelBuilder.Entity<OrderItem>()
                    .HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade); // Cascade delete when an Order is deleted

            modelBuilder.Entity<OrderItem>()
                    .HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                .WithMany(s=> s.Orders)
                .HasForeignKey(o => o.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<Order>().OwnsOne(o => o.ShipToAddress);



            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "StoreOwner", NormalizedName = "STOREOWNER" },
                new IdentityRole { Id = "2", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );

            // Seed Users
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "user1",
                    UserName = "storeowner1",
                    NormalizedUserName = "STOREOWNER1",
                    Email = "storeowner1@example.com",
                    NormalizedEmail = "STOREOWNER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password1")
                },
                new AppUser
                {
                    Id = "superadmin",
                    UserName = "superadmin",
                    NormalizedUserName = "SUPERADMIN",
                    Email = "superadmin@example.com",
                    NormalizedEmail = "SUPERADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "SuperPassword")
                }
            );

            // Seed user-role relationships
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "user1", RoleId = "1" }, // StoreOwner
                new IdentityUserRole<string> { UserId = "superadmin", RoleId = "2" } // SuperAdmin
            );
        }
    }
}
