using RestWithASPNET10.Data.Converter.Implementations;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Interfaces;
using RestWithASPNET10.Services.Interfaces;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {

        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServices(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonDTO> FindAll()
        {
            
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO? FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.CreateT(entity);
            return _converter.Parse(entity);
             
        }
        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.UpdateT(entity);
            return _converter.Parse(entity);
        }

        public void Delete(int id)
        {
            _repository.DeleteT(id);
        }


    }
}