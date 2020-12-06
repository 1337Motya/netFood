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

        public virtual DbSet<Admininstrator> Admininstrators { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dessert> Desserts { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaDoughType> PizzaDoughTypes { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=netFoodDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admininstrator>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admininstrators)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Admininst__UserI__45F365D3");
            });

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

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__Bundles__PizzaId__38996AB5");

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

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Managers__UserId__48CFD27E");
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

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Pizzas__Category__267ABA7A");
            });

            modelBuilder.Entity<PizzaDoughType>(entity =>
            {
                entity.Property(e => e.DoughType).HasMaxLength(255);

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.PizzaDoughTypes)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("FK__PizzaDoug__Pizza__2C3393D0");
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

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Staff__UserId__4BAC3F29");
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
