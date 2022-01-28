using System.Threading.Tasks;

namespace F1Api.Handlers;

public interface IDriversHandler
{
    Task<Driver> GetDriver();
}

public class DriversHandler : IDriversHandler
{
    public async Task<Driver> GetDriver()
    {
        var d = new Driver
        {
            FirstName = "Daniel",
            LastName = "Ricardo",
            DateOfBirth = DateTime.Parse("1.6.1989"),
            FirstF1Season = 2011,
            Nationality = "Australian"
        };
        return await Task.FromResult(d);
    } 
}