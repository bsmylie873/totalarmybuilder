using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : Controller
{
    [HttpGet("{id}", Name = "GetUnit")]
    public ActionResult GetUnit(int id)
    {
        return Ok(new { id = 11, name = "Tzar Guard", cost = 1000, avatar = "avatar_details" });
    }
    
}