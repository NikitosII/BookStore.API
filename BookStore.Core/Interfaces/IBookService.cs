using BookStore.Core.Models;

namespace BookStore.BusinessLogic.Services
{
    public interface IBookService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetBooksWithFilters(string search, string sortItem, string sortBy);
        Task<Guid> UpdateBook(Guid id, string title, string description, string author, DateTime dateTime);
    }
}