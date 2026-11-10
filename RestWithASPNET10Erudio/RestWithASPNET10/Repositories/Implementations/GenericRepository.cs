using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Base;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Interfaces;

namespace RestWithASPNET10.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public List<T> FindAll()
        {
            return _dataset.ToList();
        }
        public T FindById(long id)
        {
            return _dataset.Find(id);
        }
        public T CreateT(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public T UpdateT(T item)
        {
            var existing = _dataset.Find(item.Id);
            if (existing == null)
            {
                throw new Exception($"Person with ID {item.Id} not found.");
            }
            _context.Entry(existing).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }
        public void DeleteT(int id)
        {
            var Find = _dataset.Find(id);
            if (Find!= null)
            {
                _context.Remove(Find);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }
    }
}
