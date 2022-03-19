using pear_project;

public class PearService : IPearService
{

    private IPearRepository _pearRepository;

    public PearService(IPearRepository pearRepository)
    {
        _pearRepository = pearRepository;
    }



    public async Task<Person> CreatePerson(Person person)
    {
        var existCheck = await _pearRepository.FindPersonByName(person.Name);
        if (existCheck != null)

        {
            return await _pearRepository.CreatePerson(person);
        }
        else
        {
            throw new Exception();

        }
    }

    public async Task<Person> DeletePerson(Person person)
    {
        var existCheck = await _pearRepository.FindPersonById(person.Id);
        if (existCheck != null)
        {
            return await _pearRepository.DeletePerson(person);
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<List<Person>> FindPersonByGender(PersonDetail personDetail)
    {
        return await _pearRepository.FindPersonByGender(personDetail);
    }

    public async Task<Person> FindPersonById(int id)
    {
        return await _pearRepository.FindPersonById(id);
    }

    public async Task<List<Person>> FindPersonByName(string personName)
    {
        return await _pearRepository.FindPersonByName(personName);
    }

    public async Task<List<Person>> GetAllPerson()
    {
        return await _pearRepository.GetAllPerson();
    }

    public async Task<List<Person>> GetAllPersonByDutyCategory(DutyCategory dutyCategory)
    {
        return await _pearRepository.GetAllPersonByDutyCategory(dutyCategory);
    }

    public async Task<List<Person>> GetAllPersonSortByFeeByCategories(Person person)
    {
       return await _pearRepository.GetAllPersonSortByFeeByCategories(person);
    }

    public async Task<List<Person>> GetAllPersonSortByRatingsByCategories(Person person)
    {
        return await _pearRepository.GetAllPersonSortByRatingsByCategories(person);
    }

    public async Task<Person> UpdatePerson(int id, Person person)
    {
        return await _pearRepository.UpdatePerson(id, person);
    }
}