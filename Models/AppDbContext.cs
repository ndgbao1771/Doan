using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using App.Models;

using App.Models.Contacts;
using App.Models.Blog;
using App.Models.Products;

namespace App.Models
{
    // App.Models.AppDbContext
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Phương thức khởi tạo này chứa options để kết nối đến MS SQL Server
            // Thực hiện điều này khi Inject trong dịch vụ hệ thống
        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet")){
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            //Blog
            modelBuilder.Entity<Category>(entity => {
                entity.HasIndex( c => c.Slug)
                     .IsUnique();; // đánh chỉ mục cho trường dữ liệu Slug
            });


            modelBuilder.Entity<PostCategory> (entity => {
                entity.HasKey(c => (new { c.PostID, c.CategoryID}));
            });

            modelBuilder.Entity<Post> (entity => {
                entity.HasIndex( c => c.Slug)
                    .IsUnique();
            });
            //end Blog

            //Product
              modelBuilder.Entity<CategoryProduct>( entity => {
                entity.HasIndex(c => c.Slug)
                      .IsUnique();
            });

            modelBuilder.Entity<Products.ProductCategoryProduct>( entity => {
                entity.HasKey( c => (new { c.ProductID, c.CategoryID}));
            });

            modelBuilder.Entity<ProductModel>( entity => {
                entity.HasIndex( p => p.Slug)
                      .IsUnique();
            }); 
            //end Product

        }

        public DbSet<Contact> Contacts {get; set;}

        public DbSet<Category> Categories {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<PostCategory> PostCategories {get; set;}

        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductModel> Products { get; set;}
        public DbSet<ProductCategoryProduct>  ProductCategoryProducts { get; set; }

        public DbSet<ProductPhoto> ProductPhotos {get; set;}

    }
}