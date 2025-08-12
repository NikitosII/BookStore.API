
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repository
{
    public class BookRepository :  IBookRepository
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            var entities = await _context.Books
                .AsNoTracking().ToListAsync();

            var books = entities
                .Select(x => Book.Creator(x.Id, x.Title, x.Author, x.Description, x.CreatAt).book).ToList();
            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var entity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                CreatAt = book.CreatAt,
            };
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string author, string description, DateTime dateTime)
        {
            await _context.Books
               .Where(x => x.Id == id)
               .ExecuteUpdateAsync(s => s
                   .SetProperty(b => b.Title, b => title)
                   .SetProperty(b => b.Author, b => author)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.CreatAt, b => dateTime));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
