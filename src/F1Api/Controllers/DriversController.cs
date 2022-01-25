using Microsoft.AspNetCore.Mvc;

namespace F1Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;

    public DriversController(ILogger<DriversController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public Driver GetDriver()
    {
        return new Driver
        {
            FirstName = "Daniel",
            LastName = "Ricardo",
            DateOfBirth = DateTime.Parse("1.6.1989"),
            FirstF1Season = 2011,
            Nationality = "Australian"
        };
    }
    
    [HttpGet]
    [Route("allDrivers")]
    public IEnumerable<Driver> GetDrivers()
    {
        var d1 = new Driver
        {
            FirstName = "Daniel",
            LastName = "Ricardo",
            DateOfBirth = DateTime.Parse("1.6.1989"),
            FirstF1Season = 2011,
            Nationality = "Australian"
        };

        var d2 = new Driver
        {
            FirstName = "Max",
            LastName = "Verstappen",
            DateOfBirth = DateTime.Parse("9.30.1997"),
            FirstF1Season = 2015,
            Nationality = "Belgian-Dutch"
        };
        
        var res = new List<Driver>() {d1, d2};
        return res.ToArray();
    }
    
}
