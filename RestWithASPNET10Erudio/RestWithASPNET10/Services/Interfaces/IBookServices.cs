using RestWithASPNET10.Data.DTO;

namespace RestWithASPNET10.Services.Interfaces
{
    public interface IBookServices
    {
        public List<BookDTO> FindAll();
        public BookDTO FindById(long id);
        public BookDTO CreateBook(BookDTO book);
        public BookDTO UpdateBook(BookDTO book);
        public void DeleteBook(int id);
    }
}
