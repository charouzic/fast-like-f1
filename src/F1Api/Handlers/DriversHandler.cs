using System.Threading.Tasks;
using FuncSharp;

namespace F1Api.Handlers;

public interface IDriversHandler
{
    Task<IOption<Driver>> GetDriver(string surname);
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
}