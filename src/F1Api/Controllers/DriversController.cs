using F1Api.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace F1Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly IDriversHandler _driversHandler;

    public DriversController(ILogger<DriversController> logger, IDriversHandler driversHandler)
    {
        // rewrite both in functional way (instead of throwing exception I want it to be Option)
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));  
        _driversHandler = driversHandler ?? throw new ArgumentNullException(nameof(driversHandler));  
    }
    
    [HttpGet]
    public async Task<ActionResult<Driver>> GetDriver()
    {
        var response = await _driversHandler.GetDriver();
        return Ok(response);
    }
    
    [HttpGet]
    [Route("allDrivers")]
    public ActionResult<IEnumerable<Driver>> GetDrivers()
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
        
        var res = new List<Driver>() {d1, d2}.ToArray();
        return Ok(res);
    }
    
}
