using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookStore.WebAPI.Data;

namespace BookStore.WebAPI.Data;

public class BookStoreDBContext(DbContextOptions options) : IdentityDbContext<ApplicatonUser>(options)
{
//public BookStoreDBContext() { }

    //public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookLending> BookLendings { get; set;}
}
