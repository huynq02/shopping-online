using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace shopping_online.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext1")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Order_status> Order_status { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role_function> Role_function { get; set; }
        public virtual DbSet<shipping> shippings { get; set; }
        public virtual DbSet<size> sizes { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        public virtual DbSet<status_product> status_product { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<productsize> productsizes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>()
                .Property(e => e.function_name)
                .IsUnicode(false);

            modelBuilder.Entity<Order_status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Order_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.account_role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<shipping>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.shipping)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<status_product>()
                .HasMany(e => e.products)
                .WithRequired(e => e.status_product)
                .WillCascadeOnDelete(false);
        }
    }
}
