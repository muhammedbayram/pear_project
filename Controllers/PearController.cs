using Microsoft.AspNetCore.Mvc;
using pear_project;

namespace PetCity.Controllers;

[ApiController]
[Route("[controller]")]

public class PearController : ControllerBase
{
    private readonly IPearService _pearService;

    public PearController(IPearService pearService)
    {
        _pearService = pearService;
    }

    [HttpGet("GetAllPerson")]
    public async Task<List<Person>> GetAllPerson()
    {
        return await _pearService.GetAllPerson();
    }

    [HttpGet("FindPersonById")]
    public async Task<Person> FindPersonById([FromQuery] int id)
    {
        return await _pearService.FindPersonById(id);
    }

    [HttpPost("CreatePerson")]
    public async Task<Person> CreatePerson(Person person)
    {
        return await _pearService.CreatePerson(person);

    }

    [HttpDelete("DeletePerson")]
    public async Task<Person> DeletePerson(Person person)
    {

        return await _pearService.DeletePerson(person);

    }

    [HttpPut("UpdatePerson")]
    public async Task<Person> UpdatePerson([FromQuery] int id, Person person)
    {
        return await _pearService.UpdatePerson(id, person);
    }

    [HttpGet("FindPersonByName")]
    public async Task<List<Person>> FindPersonByName([FromQuery] string name)
    {
        return await _pearService.FindPersonByName(name);
    }

    [HttpGet("FindPersonByGender")]
    public async Task<List<Person>> FindPersonByGender(PersonDetail personDetail)
    {
        return await _pearService.FindPersonByGender(personDetail);
    }

    [HttpGet("GetAllPersonByDutyCategory")]
    public async Task<List<Person>> GetAllPersonByDutyCategory(DutyCategory dutyCategory)
    {
        return await _pearService.GetAllPersonByDutyCategory(dutyCategory);
    }

    [HttpGet("GetAllPersonSortByFeeByCategories")]
    public async Task<List<Person>> GetAllPersonSortByFeeByCategories(Person person)
    {
        return await _pearService.GetAllPersonSortByFeeByCategories(person);
    }

    [HttpGet("GetAllPersonSortByRatingsByCategories")]
    public async Task<List<Person>> GetAllPersonSortByRatingsByCategories(Person person)
    {
        return await _pearService.GetAllPersonSortByRatingsByCategories(person);
    }






}