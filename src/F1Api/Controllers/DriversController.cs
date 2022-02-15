using F1Api.Handlers;
using FuncSharp;
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
        // TODO: rewrite both in functional way (instead of throwing exception I want it to be Option)
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _driversHandler = driversHandler ?? throw new ArgumentNullException(nameof(driversHandler));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Driver), 200)]
    [ProducesResponseType(404)]
    [Route("{surname}")]
    public async Task<ActionResult<Driver>> GetDriver([FromRoute] string surname)
    {
        var response = await _driversHandler.GetDriver(surname);

        response.Match(
            driver => Ok(driver),
            _ => NotFound()
        );
        
        if (response.IsEmpty)
        {
            return NotFound();
        }
       
        return response.GetOrDefault();
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<List<Driver>>> GetDrivers()
    {
        var res = await _driversHandler.GetDrivers();
        
        return Ok(res.GetOrDefault());
    }
    
    [HttpPut]
    [Route("upsert")]
    public Task<ActionResult<List<Driver>>> UpsertDriver()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("delete/{lastName}")]
    public async Task<ActionResult> DeleteDriver([FromRoute] string lastName)
    {
        var response = await _driversHandler.DeleteDriver(lastName);

        // I'd love to use pattern matching here but I can't seem to find a way how to match on boolean
        if (response)
        {
            return Ok();
        }

        return NotFound();
    }
}
