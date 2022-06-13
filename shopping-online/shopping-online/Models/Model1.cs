using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace shopping_online.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<CartHE151368> CartHE151368 { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryHE151368> CategoryHE151368 { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<image_product> image_product { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Order_status> Order_status { get; set; }
        public virtual DbSet<OrdersHE151368> OrdersHE151368 { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<ProductHE151368> ProductHE151368 { get; set; }
        public virtual DbSet<ReviewHE151368> ReviewHE151368 { get; set; }
        public virtual DbSet<shipping> shippings { get; set; }
        public virtual DbSet<size> sizes { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        public virtual DbSet<status_product> status_product { get; set; }
        public virtual DbSet<UsersHE151368> UsersHE151368 { get; set; }
        public virtual DbSet<MSreplication_options> MSreplication_options { get; set; }
        public virtual DbSet<productsize> productsizes { get; set; }
        public virtual DbSet<spt_fallback_db> spt_fallback_db { get; set; }
        public virtual DbSet<spt_fallback_dev> spt_fallback_dev { get; set; }
        public virtual DbSet<spt_fallback_usg> spt_fallback_usg { get; set; }
        public virtual DbSet<spt_monitor> spt_monitor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartHE151368>()
                .HasMany(e => e.OrdersHE151368)
                .WithOptional(e => e.CartHE151368)
                .HasForeignKey(e => e.cart_id);

            modelBuilder.Entity<CartHE151368>()
                .HasMany(e => e.OrdersHE1513681)
                .WithOptional(e => e.CartHE1513681)
                .HasForeignKey(e => e.cart_id);

            modelBuilder.Entity<CategoryHE151368>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<CategoryHE151368>()
                .HasMany(e => e.ProductHE151368)
                .WithOptional(e => e.CategoryHE151368)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<CategoryHE151368>()
                .HasMany(e => e.ProductHE1513681)
                .WithOptional(e => e.CategoryHE1513681)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<image_product>()
                .HasMany(e => e.products)
                .WithRequired(e => e.image_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Order_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductHE151368>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ProductHE151368>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<ProductHE151368>()
                .HasMany(e => e.OrdersHE151368)
                .WithOptional(e => e.ProductHE151368)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<ProductHE151368>()
                .HasMany(e => e.OrdersHE1513681)
                .WithOptional(e => e.ProductHE1513681)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<ProductHE151368>()
                .HasMany(e => e.ReviewHE151368)
                .WithOptional(e => e.ProductHE151368)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<ProductHE151368>()
                .HasMany(e => e.ReviewHE1513681)
                .WithOptional(e => e.ProductHE1513681)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<ReviewHE151368>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<shipping>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.shipping)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<status_product>()
                .HasMany(e => e.products)
                .WithRequired(e => e.status_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.CartHE151368)
                .WithOptional(e => e.UsersHE151368)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.CartHE1513681)
                .WithOptional(e => e.UsersHE1513681)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.ProductHE151368)
                .WithOptional(e => e.UsersHE151368)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.ProductHE1513681)
                .WithOptional(e => e.UsersHE1513681)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.ReviewHE151368)
                .WithOptional(e => e.UsersHE151368)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<UsersHE151368>()
                .HasMany(e => e.ReviewHE1513681)
                .WithOptional(e => e.UsersHE1513681)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<spt_fallback_db>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_db>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.xfallback_drive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.phyname)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_usg>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);
        }
    }
}
