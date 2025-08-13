using BookStore.API.Contracts;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.BusinessLogic.Services; 

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            var books = await _bookService.GetBooks();
            var response = books.Select(x => new BookResponse(x.Id, x.Author, x.Title, x.Description, x.CreatAt));
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<BookResponse>>> GetBooksWithFilter([FromQuery] BookSearchParams searchParams)
        {
            if (string.IsNullOrEmpty(searchParams.search) && string.IsNullOrEmpty(searchParams.sortitem) && string.IsNullOrEmpty(searchParams.sortBy))
            {
                var allBooks = await _bookService.GetBooks();
                var books = allBooks.Select(x => new BookResponse(x.Id, x.Author, x.Title, x.Description, x.CreatAt));
                return Ok(books);
            }

            if (!string.IsNullOrEmpty(searchParams.sortitem))
            {
                var SortItems = new[] { "title", "author", "date", "id" };
                if (!SortItems.Contains(searchParams.sortitem.ToLower()))
                {
                    return BadRequest($"Invalid sort item. Valid values are: {string.Join(", ", SortItems)}");
                }
            }

            if (!string.IsNullOrEmpty(searchParams.sortBy))
            {
                var SortOrders = new[] { "asc", "desc" };
                if (!SortOrders.Contains(searchParams.sortBy.ToLower()))
                {
                    return BadRequest($"Invalid sort order. Valid values are: {string.Join(", ", SortOrders)}");
                }
            }

            var book = await _bookService.GetBooksWithFilters(
                searchParams.search,
                searchParams.sortitem,
                searchParams.sortBy);

            var response = book.Select(x => new BookResponse(x.Id, x.Author, x.Title, x.Description, x.CreatAt));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddBook([FromBody] BookRequest bookRequest)
        {
            var (book, error) = Book.Creator(
                Guid.NewGuid(), bookRequest.Title, bookRequest.Author, bookRequest.Description, bookRequest.CreatAt);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookID = await _bookService.CreateBook(book);
            return Ok(bookID);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _bookService.DeleteBook(id);
            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
        {
            var (book, error) = Book.Creator(Guid.NewGuid(), bookRequest.Title, bookRequest.Author, bookRequest.Description, bookRequest.CreatAt);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookId = await _bookService.UpdateBook(id, bookRequest.Author, bookRequest.Title, bookRequest.Description, bookRequest.CreatAt);
            return Ok(bookId);
        }

    }
}

