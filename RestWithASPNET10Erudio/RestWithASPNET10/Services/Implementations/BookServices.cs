using RestWithASPNET10.Model;
using RestWithASPNET10.Services.Interfaces;
using RestWithASPNET10.Repositories.Interfaces;
using RestWithASPNET10.Data.DTO;
using Mapster;

namespace RestWithASPNET10.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IRepository<Book> _bookRepository;

        public BookServices(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookDTO> FindAll()
        {
            return _bookRepository.FindAll().Adapt<List<BookDTO>>();
        }

        

        public BookDTO FindById(long id)
        {
            return _bookRepository.FindById(id).Adapt<BookDTO>();
        }

        

        public BookDTO CreateBook(BookDTO book)
        {
            var bookEntity = book.Adapt<Book>();
            var entity = _bookRepository.CreateT(bookEntity);
            return entity.Adapt<BookDTO>();
        }

        public BookDTO UpdateBook(BookDTO book)
        {
            var bookEntity = book.Adapt<Book>();
            var entity = _bookRepository.UpdateT(bookEntity);
            return entity.Adapt<BookDTO>();
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteT(id);
        }


        
    }
}
