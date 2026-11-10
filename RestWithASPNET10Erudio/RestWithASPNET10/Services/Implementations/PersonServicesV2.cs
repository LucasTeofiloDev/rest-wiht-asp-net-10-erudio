using RestWithASPNET10.Data.Converter.Implementations;
using RestWithASPNET10.Data.DTO.V2;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Interfaces;
using RestWithASPNET10.Services.Interfaces;

namespace RestWithASPNET10.Services.Implementations.v2
{
    public class PersonServicesV2
    {

        private IRepository<Person> _repository;
        private readonly PersonConverterV2 _converter;

        public PersonServicesV2(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverterV2();
        }
        

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.CreateT(entity);
            return _converter.Parse(entity);
             
        }
       


    }
}