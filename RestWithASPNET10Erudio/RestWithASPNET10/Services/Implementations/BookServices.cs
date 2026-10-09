using RestWithASPNET10.Model;
using RestWithASPNET10.Services.Interfaces;
using RestWithASPNET10.Repositories.Interfaces;

namespace RestWithASPNET10.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;

        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        

        public Book CreateBook(Book book)
        {
           return _bookRepository.CreateBook(book);
        }

        public Book UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }


        
    }
}
