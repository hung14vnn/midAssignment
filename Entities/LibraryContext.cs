using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace midAssignment.Entities
{
     public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(p => p.Categories)
                .WithMany(c => c.Books)
                .HasForeignKey(p => p.CategoryID);         
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
        public DbSet<BookeBorrowingRequestDetails>? BookeBorrowingRequestDetails { get; set; }

    }
}