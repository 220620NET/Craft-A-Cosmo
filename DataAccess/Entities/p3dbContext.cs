using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class p3dbContext : DbContext
    {
        public p3dbContext()
        {
        }

        public p3dbContext(DbContextOptions<p3dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductOption> ProductOptions { get; set; } = null!;
        public virtual DbSet<SavedAddress> SavedAddresses { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Zipcode> Zipcodes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "DOTNET_P3");

                entity.Property(e => e.ApartmentNum).HasColumnName("apartmentNum");

                entity.Property(e => e.CityFk).HasColumnName("city_fk");

                entity.Property(e => e.StateFk).HasColumnName("state_fk");

                entity.Property(e => e.StreetAddy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("streetAddy");

                entity.Property(e => e.UserIdFk).HasColumnName("userId_fk");

                entity.Property(e => e.ZipcodeFk).HasColumnName("zipcode_fk");

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__city_fk__7167D3BD");

                entity.HasOne(d => d.StateFkNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__state_f__725BF7F6");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__Address__userId___6F7F8B4B");

                entity.HasOne(d => d.ZipcodeFkNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ZipcodeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__zipcode__7073AF84");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart", "DOTNET_P3");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.BillingAddressIdFk).HasColumnName("billingAddressId_fk");

                entity.Property(e => e.PurchaseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("purchaseTime");

                entity.Property(e => e.ShippingAddressIdFk).HasColumnName("shippingAddressId_fk");

                entity.Property(e => e.ShippingNote)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shippingNote");

                entity.Property(e => e.UserIdFk).HasColumnName("userId_fk");

                entity.HasOne(d => d.BillingAddressIdFkNavigation)
                    .WithMany(p => p.CartBillingAddressIdFkNavigations)
                    .HasForeignKey(d => d.BillingAddressIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__billingAdd__79FD19BE");

                entity.HasOne(d => d.ShippingAddressIdFkNavigation)
                    .WithMany(p => p.CartShippingAddressIdFkNavigations)
                    .HasForeignKey(d => d.ShippingAddressIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__shippingAd__7908F585");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__userId_fk__7AF13DF7");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category", "DOTNET_P3");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "DOTNET_P3");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("cityName");

                entity.Property(e => e.StateIdFk).HasColumnName("stateId_fk");

                entity.HasOne(d => d.StateIdFkNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__city__stateId_fk__6C190EBB");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items", "DOTNET_P3");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.CartFk).HasColumnName("cart_fk");

                entity.Property(e => e.ProductIdFk).HasColumnName("productId_fk");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CartFkNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CartFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__items__cart_fk__0C1BC9F9");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__items__productId__0B27A5C0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "DOTNET_P3");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CategoryIdFk).HasColumnName("categoryId_fk");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Listed).HasColumnName("listed");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("productImage");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductOptionsIdFk).HasColumnName("productOptionsId_fk");

                entity.HasOne(d => d.CategoryIdFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__categor__075714DC");

                entity.HasOne(d => d.ProductOptionsIdFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductOptionsIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__product__084B3915");
            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.HasKey(e => e.ProductOptionsId)
                    .HasName("PK__productO__F53BADB7628C9AB8");

                entity.ToTable("productOptions", "DOTNET_P3");

                entity.Property(e => e.ProductOptionsId).HasColumnName("productOptionsId");

                entity.Property(e => e.ColorVariant)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("colorVariant");

                entity.Property(e => e.SizeVariant)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sizeVariant");

                entity.Property(e => e.SoundVariant)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("soundVariant");
            });

            modelBuilder.Entity<SavedAddress>(entity =>
            {
                entity.ToTable("savedAddress", "DOTNET_P3");

                entity.Property(e => e.SavedAddressId).HasColumnName("savedAddressId");

                entity.Property(e => e.BillingAddressIdFk).HasColumnName("billingAddressId_fk");

                entity.Property(e => e.UserIdFk).HasColumnName("userId_fk");

                entity.HasOne(d => d.BillingAddressIdFkNavigation)
                    .WithMany(p => p.SavedAddresses)
                    .HasForeignKey(d => d.BillingAddressIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__savedAddr__billi__762C88DA");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.SavedAddresses)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__savedAddr__userI__753864A1");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "DOTNET_P3");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stateName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "DOTNET_P3");

                entity.HasIndex(e => e.Username, "UQ__users__F3DBC572A6030699")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('User')");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Zipcode>(entity =>
            {
                entity.ToTable("zipcode", "DOTNET_P3");

                entity.Property(e => e.ZipcodeId).HasColumnName("zipcodeId");

                entity.Property(e => e.CityIdFk).HasColumnName("cityId_fk");

                entity.Property(e => e.ZipCode1).HasColumnName("zipCode");

                entity.HasOne(d => d.CityIdFkNavigation)
                    .WithMany(p => p.Zipcodes)
                    .HasForeignKey(d => d.CityIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__zipcode__cityId___6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
