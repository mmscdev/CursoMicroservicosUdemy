using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services;

namespace RestWithAspNetUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]

    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }


    [HttpGet("{id}")]

    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);

        if (person == null) return NotFound();

        return Ok(person);
    }

    [HttpPost]

    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest();


        return Ok(_personService.Create(person));
    }


    [HttpPut]

    public IActionResult Put([FromBody] Person person)
    {
        if (person == null) return BadRequest();


        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(long id)
    {
        _personService.Delete(id);

        return Ok();
    }
}
