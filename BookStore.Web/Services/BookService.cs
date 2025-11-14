using System;
using System.Data.Common;
using AutoMapper;
using BookStore.WebAPI.Data;
using BookStore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebAPI.Services;

public class BookService(BookStoreDBContext dBContext) : IBookService
{
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var data = await dBContext.Books.AsSingleQuery()
        .OrderBy(c => c.Title)
        .ToListAsync();

        return data;
    }
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var book = await dBContext.Books.FindAsync(id);
        return book;
    }

    public async Task<int> AddBookAsync(BookModel bookModel)
    {
        var book = new Book()
        {
            Title = bookModel.Title,
            Author = bookModel.Author,
        };

        dBContext.Books!.Add(book);
        await dBContext.SaveChangesAsync();

        return book.BookId;
    }

    public async Task<Book> UpdateBookAsync(BookModel bookModel)
    {
        //Set the Product Id
        var existingBook = dBContext.Books.FirstOrDefault(b => b.BookId == bookModel.BookId);

        if (existingBook != null)
        {
            var book = new Book()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
            };

            dBContext.Books!.Update(book);
            await dBContext.SaveChangesAsync();

            return book;
        }

        return null;
    }
    
    public async Task DeleteBookAsync(Book book)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        dBContext.Books.Remove(book);
    }
}
