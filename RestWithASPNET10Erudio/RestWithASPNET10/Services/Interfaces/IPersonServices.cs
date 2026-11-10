using RestWithASPNET10.Data.DTO.V1;


namespace RestWithASPNET10.Services.Interfaces
{
    public interface IPersonServices
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO? FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        void Delete(int id);
    }
}