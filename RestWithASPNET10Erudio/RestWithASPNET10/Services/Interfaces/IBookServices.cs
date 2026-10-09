using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services.Interfaces
{
    public interface IBookServices
    {
        public List<Book> FindAll();
        public Book FindById(long id);
        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public void DeleteBook(int id);
    }
}
