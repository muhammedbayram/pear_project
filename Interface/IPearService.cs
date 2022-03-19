using System.Collections.Generic;

namespace pear_project
{
    public interface IPearService
    {
        Task<List<Person>> GetAllPerson();
        Task<Person> FindPersonById(int id);
        Task<List<Person>> FindPersonByName(string personName);
        Task<List<Person>> FindPersonByGender(PersonDetail personDetail);
        Task<List<Person>> GetAllPersonByDutyCategory(DutyCategory dutyCategory);

        Task<List<Person>> GetAllPersonSortByFeeByCategories(Person person);
        Task<List<Person>> GetAllPersonSortByRatingsByCategories(Person person);


        Task<Person> CreatePerson(Person person);
        Task<Person> UpdatePerson(int id, Person person);
        Task<Person> DeletePerson(Person person);


    }
}