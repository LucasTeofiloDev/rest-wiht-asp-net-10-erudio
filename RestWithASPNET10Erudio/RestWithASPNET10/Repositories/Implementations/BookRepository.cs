using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Interfaces;

namespace RestWithASPNET10.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly MSSQLContext _mSSQLContext;

        public BookRepository(MSSQLContext mSSQLContext)
        {
            _mSSQLContext = mSSQLContext;
        }
        public Book CreateBook(Book book)
        {
            _mSSQLContext.Add(book);
            _mSSQLContext.SaveChanges();
            return book;
        }

        public void DeleteBook(int id)
        {
            var FindBook = _mSSQLContext.Book.Find(id);
            if (FindBook != null)
            {
                _mSSQLContext.Book.Remove(FindBook);
            }
            
        }

        public List<Book> FindAll()
        {
            return _mSSQLContext.Book.ToList();
        }

        

        public Book FindById(long id)
        {
            
           return _mSSQLContext.Book.Find(id);

        }

        

        public Book UpdateBook(Book book)
        {
            _mSSQLContext.Update(book);
            _mSSQLContext.SaveChanges();
            return book;
        }
    }
}
