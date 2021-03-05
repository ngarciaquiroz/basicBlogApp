
using basicBlogAppModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace basicBlogAppRepository.Data
{
    public class BasicBlogAppContext : DbContext
    {
        public BasicBlogAppContext(DbContextOptions<BasicBlogAppContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var posts = new Post[] {
                new Post { ID = 1, Title = "Post 1", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", Author = "Nicolas Garcia", PublishDate = DateTime.Now },
                new Post { ID = 2, Title = "Post 2", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", Author = "Carolina Garcia", PublishDate = DateTime.Now },
                new Post { ID = 3, Title = "Post 3", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", Author = "Alejandra Garcia", PublishDate = DateTime.Now },
                new Post { ID = 4, Title = "Post 4", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", Author = "Trufa Garcia", PublishDate = DateTime.Now }
            };

            modelBuilder.Entity<Post>().HasData(posts);
        }

    }
}
