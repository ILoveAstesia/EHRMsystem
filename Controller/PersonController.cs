using EHRMsystem.Data;
using EHRMsystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BlazorTestStu.Controllers;

[Route("Person")]//这里有个问题在之后修复了
[ApiController]
public class PersonsController : Controller
{
    private readonly EHRMContext _db;

    public PersonsController(EHRMContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetPersons()
    {
        return (await _db.Persons.ToListAsync()).OrderByDescending(p => p.GetId()).ToList();
    }
}