using BookStore.Core.Models;

namespace BookStore.DataAccess.Repository
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> GetAll();
        Task<Guid> Update(Guid id, string title, string author, string description, DateTime dateTime);
    }
}