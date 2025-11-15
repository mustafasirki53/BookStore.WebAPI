namespace BookStore.WebAPI.Tests;

using BookStore.WebAPI.Controllers;
using BookStore.WebAPI.Services;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BookStore.WebAPI.Models;
using AutoMapper;
using BookStore.WebAPI.Data;
using Microsoft.Extensions.Logging;

public class UnitTest1
{
    [Fact]
    public void Test_GetAllBooks()
    {
        // Arrange
        var mapper = new Moq.Mock<AutoMapper.IMapper>().Object;
        var logger = new Moq.Mock<Microsoft.Extensions.Logging.ILogger<BookStoreController>>().Object;
        var bookService = new Moq.Mock<IBookService>().Object;

        // Act
        BookStoreController controller = new BookStoreController(mapper, logger, bookService);
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
    }
        [Fact]
        public async Task UpdateBook_ReturnsOk_WhenBookExists()
        {
            // Arrange
            var bookId = 1;
            var bookModel = new BookModel { BookId = bookId, Author = "Updated Author" };
            var updatedBook = new BookModel { BookId = bookId, Author = "Updated Author" };

            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(s => s.UpdateBookAsync(bookModel)).ReturnsAsync(updatedBook);

            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<BookStoreController>>();

            var controller = new BookStoreController(mapperMock.Object, loggerMock.Object, bookServiceMock.Object);

            // Act
            var result = await controller.Put(bookId, bookModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedModel = Assert.IsType<BookModel>(okResult.Value);
            Assert.Equal("Updated Author", returnedModel.Author);
        }

        [Fact]
        public async Task UpdateBook_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var bookId = 1;
            var bookModel = new BookModel { BookId = 2, Author = "Author" };

            var bookServiceMock = new Mock<IBookService>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<BookStoreController>>();

            var controller = new BookStoreController(mapperMock.Object, loggerMock.Object, bookServiceMock.Object);

            // Act
            var result = await controller.Put(bookId, bookModel);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateBook_ReturnsNotFound_WhenBookDoesNotExist()
        {
            // Arrange
            var bookId = 1;
            var bookModel = new BookModel { BookId = bookId, Author = "Author" };

            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(s => s.UpdateBookAsync(bookModel)).ReturnsAsync((BookModel)null);

            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<BookStoreController>>();

            var controller = new BookStoreController(mapperMock.Object, loggerMock.Object, bookServiceMock.Object);

            // Act
            var result = await controller.Put(bookId, bookModel);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

    [Fact]
    public async Task GetBookById_ReturnsOk_WhenBookExists()
    {
        // Arrange
        var bookId = 1;
        var book = new Book { BookId = bookId, Author = "Mustafa" };
        var bookModel = new BookModel { BookId = bookId, Author = "Mustafa" };

        var bookServiceMock = new Mock<IBookService>();
        bookServiceMock.Setup(s => s.GetBookByIdAsync(bookId)).ReturnsAsync(book);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<BookModel>(book)).Returns(bookModel);

        var loggerMock = new Mock<ILogger<BookStoreController>>();

        var controller = new BookStoreController(mapperMock.Object, loggerMock.Object, bookServiceMock.Object);

        // Act
        var result = await controller.GetBookById(bookId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedModel = Assert.IsType<BookModel>(okResult.Value);
        Assert.Equal("Mustafa", returnedModel.Author);
    }

    [Fact]
    public async Task GetBookById_ReturnsNotFound_WhenBookDoesNotExist()
    {
        // Arrange
        var bookId = 99;
        var bookServiceMock = new Mock<IBookService>();
        bookServiceMock.Setup(s => s.GetBookByIdAsync(bookId)).ReturnsAsync((Book)null);

        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<BookStoreController>>();

        var controller = new BookStoreController(mapperMock.Object, loggerMock.Object, bookServiceMock.Object);

        // Act
        var result = await controller.GetBookById(bookId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
