using BookStore.Core.Models;
using BookStore.DataAccess.Repository;

namespace BookStore.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetAll();

        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.Create(book);
        }
        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookRepository.Delete(id);

        }
        public async Task<Guid> UpdateBook(Guid id, string title, string description, string author, DateTime dateTime)
        {
            return await _bookRepository.Update(id, title, description, author, dateTime);
        }

        public async Task<List<Book>> GetBooksWithFilters(string search, string sortItem, string sortBy)
        {
            return await _bookRepository.GetWithFilter(search, sortItem, sortBy);
        }

    }
}

