using System;
using BookStore.WebAPI.Data;
using BookStore.WebAPI.Models;

namespace BookStore.WebAPI.Services;

public interface IBookService
{
    public Task<IEnumerable<Book>> GetAllBooks();

    public Task<Book?> GetBookByIdAsync(int id);

    public Task<int> AddBookAsync(BookModel bookModel);
    public Task<Book> UpdateBookAsync(BookModel bookModel);
    public Task DeleteBookAsync(Book book);
}
