using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Base;

namespace RestWithASPNET10.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {

        public List<T> FindAll();
        public T FindById(long id);
        public T CreateT(T item);
        public T UpdateT(T item);
        public void DeleteT(int id);
    }
}
