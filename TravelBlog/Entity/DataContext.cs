using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelBlog.Models;

namespace TravelBlog.Entity
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DbCon") { }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Comments)
                .WithRequired(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId)
                .WillCascadeOnDelete(false); // Bu cascade silmeyi devre dışı bırakır

            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Likes)
                .WithRequired(l => l.BlogPost)
                .HasForeignKey(l => l.BlogPostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.BlogPosts)
                .WithRequired(b => b.AppUser)
                .HasForeignKey(b => b.AppUserId)
                .WillCascadeOnDelete(false);




        }

    }
}