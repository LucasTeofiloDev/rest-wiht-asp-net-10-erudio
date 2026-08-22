using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServicesImpl : IPersonServices
    {
        public Person Update(Person person)
        {
            person.Id = new Random().Next(1, 1000); //Simula ID
            return person;
        }

        public Person FindById(long id)
        {
            var person = mockPerson((int)id);

            return person;
        }

        private Person mockPerson(int i)
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "John " + i,
                LastName = "Doe " + i,
                Address = "123 Main Street " + i,
                Gender = (i % 2) == 0 ? "Male" : "Feminine"
            };
            return person;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            // Simulate deletion logic
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(mockPerson(i));
            }
            return persons;
        }



    }
}