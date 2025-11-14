using AutoMapper;
using BookStore.WebAPI.Data;
using BookStore.WebAPI.Models;
using BookStore.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private readonly IBookService _bookService;
        public BookStoreController(IMapper mapper, ILogger<BookStoreController> logger, IBookService bookService)
        {
            _mapper = mapper;
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(_mapper.Map<IEnumerable<BookModel>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(_mapper.Map<BookModel>(book));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            var id = await _bookService.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new { controller = "BookStore", id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookModel bookModel)
        {
            if (id != bookModel.BookId)
            {
                return BadRequest();
            }
            var result = await _bookService.UpdateBookAsync(bookModel);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(book);
            // Returns a 204 No Content response
            return NoContent(); 
        }
    }
}
