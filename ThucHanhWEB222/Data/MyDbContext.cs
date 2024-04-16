using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using ThucHanhWEB222.Models;

namespace ThucHanhWEB222.Data


{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Books> Book { get; set; }
        public DbSet<Authors> Author { get; set; }
        public DbSet<Publishers> Publisher { get; set; }
        public DbSet<BookAuthor> Book_Author { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookID);
            builder.Entity<BookAuthor>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorID);
        }
    }
}
