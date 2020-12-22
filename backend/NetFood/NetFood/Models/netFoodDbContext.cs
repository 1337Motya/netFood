using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetFood.Models
{
    public partial class netFoodDbContext : DbContext
    {
        public netFoodDbContext()
        {
        }

        public netFoodDbContext(DbContextOptions<netFoodDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dessert> Desserts { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaDoughType> PizzaDoughTypes { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=netFoodDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Bundles__Categor__37A5467C");

                entity.HasOne(d => d.Dessert)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.DessertId)
                    .HasConstraintName("FK__Bundles__Dessert__3B75D760");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.DrinkId)
                    .HasConstraintName("FK__Bundles__DrinkId__3A81B327");

                entity.HasOne(d => d.PizzaOrder)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.PizzaOrderId)
                    .HasConstraintName("FK_Bundles_PizzaOrders");

                entity.HasOne(d => d.Snack)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.SnackId)
                    .HasConstraintName("FK__Bundles__SnackId__398D8EEE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Dessert>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Desserts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Desserts__Catego__31EC6D26");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Drinks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Drinks__Category__34C8D9D1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderSum).HasColumnType("decimal(10, 5)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__OrderItem__Categ__412EB0B6");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__403A8C7D");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<PizzaDoughType>(entity =>
            {
                entity.Property(e => e.DoughType).HasMaxLength(255);

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.PizzaDoughTypes)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("FK__PizzaDoug__Pizza__2C3393D0");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__Categ__5FB337D6");

                //entity.HasOne(d => d.PizzaDoughType)
                //    .WithMany(p => p.PizzaOrders)
                //    .HasForeignKey(d => d.PizzaDoughTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__PizzaOrde__Pizza__5EBF139D");

                //entity.HasOne(d => d.Pizza)
                //    //.WithMany(p => p.PizzaOrders)
                //    //.HasForeignKey(d => d.PizzaId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__PizzaOrde__Pizza__5CD6CB2B");

                //entity.HasOne(d => d.PizzaSize)
                //    .WithMany(p => p.PizzaOrders)
                //    .HasForeignKey(d => d.PizzaSizeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__PizzaOrde__Pizza__5DCAEF64");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.PizzaSizes)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("FK__PizzaSize__Pizza__29572725");
            });

            modelBuilder.Entity<Snack>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Snacks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Snacks__Category__2F10007B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Patronymic).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
