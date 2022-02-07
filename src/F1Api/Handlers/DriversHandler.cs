using System.Threading.Tasks;
using F1Api.Domain.Contract;
using FuncSharp;

namespace F1Api.Handlers;

public interface IDriversHandler
{
    Task<IOption<Driver>> GetDriver(string surname);
    Task<IOption<List<Driver>>> GetDrivers();
}

public class DriversHandler : IDriversHandler
{
    private readonly IDriverRepository _repository;

    public DriversHandler(IDriverRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<IOption<Driver>> GetDriver(string surname)
    {
        return await _repository.GetDriverAsync(surname);
    }

    public async Task<IOption<List<Driver>>> GetDrivers()
    {
        var d1 = new Driver
        {
            FirstName = "Daniel",
            LastName = "Ricardo",
            //DateOfBirth = DateOnly.Parse("1.6.1989"),
            FirstSeason = 2011,
            Country = "Australian"
        };
        
        var d2 = new Driver
        {
            FirstName = "Max",
            LastName = "Verstappen",
            //DateOfBirth = DateOnly.Parse("9.30.1997"),
            FirstSeason = 2015,
            Country = "Belgian-Dutch"
        };

        var res = new List<Driver>() {d1, d2};
        return await Task.FromResult(Option.Create(res));
    }
}