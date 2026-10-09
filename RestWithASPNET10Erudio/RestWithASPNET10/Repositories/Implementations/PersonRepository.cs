using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Interfaces;
namespace RestWithASPNET10.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        public Person? FindById(long id)
        {
            return _context.Persons.Find(id);
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null)
            {
                throw new Exception($"Person with ID {person.Id} not found.");
            }
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var existingPerson = _context.Persons.Find(id);
            if (existingPerson == null)
            {
                throw new Exception($"Person with ID {id} not found.");
            }
            _context.Remove(existingPerson);
            _context.SaveChanges();
        }
    }
}
