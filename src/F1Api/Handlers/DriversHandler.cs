using System.Threading.Tasks;
using FuncSharp;

namespace F1Api.Handlers;

public interface IDriversHandler
{
    Task<IOption<Driver>> GetDriver(string surname);
    Task<IOption<List<Driver>>> GetDrivers();
}

public class DriversHandler : IDriversHandler
{
    public async Task<IOption<Driver>> GetDriver(string surname)
    {
        var d = new Driver
        {
            FirstName = "Daniel",
            LastName = "Ricardo",
            DateOfBirth = DateTime.Parse("1.6.1989"),
            FirstF1Season = 2011,
            Nationality = "Australian"
        };
        
        if (d.LastName != surname)
        {
            return Option.Empty<Driver>();
        }
        
        return await Task.FromResult(Option.Create(d));
    }

    public async Task<IOption<List<Driver>>> GetDrivers()
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
        return await Task.FromResult(Option.Create(res));
    }
}