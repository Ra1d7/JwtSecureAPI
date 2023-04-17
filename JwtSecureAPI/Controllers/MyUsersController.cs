using GettingStartedAPI.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace GettingStartedAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var t = new string[] { "Moath's", "API" };
        return t;
    }
    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    [Authorize(Policy = PolicyConstants.MustHaveEmployeeId)]
    public string Get(int id)
    {
        return $"the secret value is {id*253}";
    }
    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }
    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    [Authorize(Policy = PolicyConstants.MustBeAVeteranEmployee)]
    public void Put(int id, [FromBody] string value)
    {
    }
    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyConstants.MustBeAnOwner)]
    public void Delete(int id)
    {
    }
}
