using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookBeauty.Services.Database;

public partial class _200101Context : DbContext
{
    public _200101Context()
    {
    }

    public _200101Context(DbContextOptions<_200101Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<HairDresser> HairDressers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=200101; user=ms; Password=123; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentStatusId).HasColumnName("AppointmentStatusID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.HairDresserId)
                .HasMaxLength(50)
                .HasColumnName("HairDresserID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AppointmentStatus).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentStatusId)
                .HasConstraintName("FK_Appointment_AppointmentStatus");

            entity.HasOne(d => d.HairDresser).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.HairDresserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_HairDresser");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Service");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Appointment_User");
        });

        modelBuilder.Entity<AppointmentStatus>(entity =>
        {
            entity.ToTable("AppointmentStatus");

            entity.Property(e => e.AppointmentStatusId)
                .ValueGeneratedNever()
                .HasColumnName("AppointmentStatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.ToTable("Favorite");

            entity.Property(e => e.FavoriteId)
                .ValueGeneratedNever()
                .HasColumnName("FavoriteID");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Favorite_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Favorite_User");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnName("GenderID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<HairDresser>(entity =>
        {
            entity.ToTable("HairDresser");

            entity.Property(e => e.HairDresserId)
                .HasMaxLength(50)
                .HasColumnName("HairDresserID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderStatus");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_Product");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("OrderStatus");

            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedNever()
                .HasColumnName("OrderStatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("CategoryID");
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Review_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Review_User");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.LongDescription).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ShortDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_User_Gender");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
