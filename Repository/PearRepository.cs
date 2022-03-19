using Microsoft.EntityFrameworkCore;
using pear_project;

public class PearRepository : IPearRepository
{
    PearDbContext _context;

    public PearRepository(PearDbContext context)
    {
        _context = context;
    }

    public async Task<Person> CreatePerson(Person person)
    {
        try
        {
            await _context.Set<Person>().AddAsync(person);
            await _context.SaveChangesAsync();
            return person;

        }
        catch (Exception ex)
        {
            return null;

        }
    }

    public async Task<Person> DeletePerson(Person person)
    {
        try
        {
            _context.Set<Person>().Remove(person);
            _context.SaveChangesAsync();
            return person;

        }
        catch (Exception ex)
        {
            return null;

        }
    }

    // public async Task<Person> FindPersonById(int id)
    // {
    //     try
    //     {
    //         return await _context.Set<Person>().FirstOrDefaultAsync(p=>p.Id == id);
    //     }
    //     catch (Exception e)
    //     {
    //         return null;
    //     }
    // }

    public async Task<List<Person>> FindPersonByName(string personName)
    {
        try
        {
            return await _context.Set<Person>().Where(c => c.Name == personName).ToListAsync();
        }
        catch (Exception e)
        {
            return null;
        }

    }

    public async Task<List<Person>> GetAllPerson()
    {
        try
        {
            return await _context.Set<Person>().ToListAsync();

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Person>> GetAllPersonByDutyCategory(DutyCategory dutyCategory)
    {
        try
        {
            var getPersons = await _context.Set<Person>().Where(a => a.PersonDetail.dutyCategories == dutyCategory).ToListAsync();

            if (getPersons != null)
            {
                return getPersons;
            }
            else
            {
                return null;
            }

        }
        catch (Exception ex)
        {
            return null;

        }
    }

    public async Task<Person> FindPersonById(int id)
    {
        try
        {
            var getPerson = await _context.Set<Person>().SingleOrDefaultAsync(p => p.Id == id);

            if (getPerson != null)
            {
                return getPerson;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;

        }
    }

    public async Task<Person> UpdatePerson(int id, Person person)
    {
        try
        {
            // bakılacak

            var personUpdate = await _context.Persons.FindAsync(id);
            personUpdate.Name = person.Name;
            personUpdate.PersonDetail.Description = person.PersonDetail.Description;
            personUpdate.PersonDetail.DutyFee = person.PersonDetail.DutyFee;
            personUpdate.PersonDetail.dutyCategories = person.PersonDetail.dutyCategories;


            await _context.SaveChangesAsync();
            return personUpdate;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Person>> FindPersonByGender(PersonDetail personDetail)
    {
        try
        {
            var getPersons = await _context.Set<Person>().Where(p => p.PersonDetail.gender == personDetail.gender).ToListAsync();
            if (getPersons != null)
            {
                return getPersons;
            }
            else
            {
                return null;
            }

        }
        catch (Exception ex)
        {

            return null;

        }
    }

    public async Task<List<Person>> GetAllPersonSortByFeeByCategories(Person person)
    {
        try
        {
            var getPersonsSorting = await _context.Persons.Where(p => p.PersonDetail.dutyCategories == person.PersonDetail.dutyCategories)
            .OrderByDescending(p => p.PersonDetail.DutyFee).ToListAsync();

            if (getPersonsSorting != null)
            {
                return getPersonsSorting;
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Person>> GetAllPersonSortByRatingsByCategories(Person person)
    {
        try
        {
            var getPersonsSorting = await _context.Persons.Where(p => p.PersonDetail.dutyCategories == person.PersonDetail.dutyCategories)
            .OrderByDescending(p => p.PersonDetail.Rating).ToListAsync();

            if (getPersonsSorting != null)
            {
                return getPersonsSorting;
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}