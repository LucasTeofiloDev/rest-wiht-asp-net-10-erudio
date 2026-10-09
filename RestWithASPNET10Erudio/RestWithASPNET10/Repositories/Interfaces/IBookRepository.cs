using RestWithASPNET10.Model;
namespace RestWithASPNET10.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> FindAll();
        public Book FindById(long id);
        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public void DeleteBook(int id);
        
    }
}
