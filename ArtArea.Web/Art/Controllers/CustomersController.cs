using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Art
{
    [Route("api/[controller]")]
    [ApiController]
public class CustomersController : ControllerBase
{
    // GET api/values
    [HttpGet,Authorize]
    public IEnumerable<string> Get()
    {
 	return new string[] { "User1", "User2" };
    }
 
}
}