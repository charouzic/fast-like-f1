using System.Threading.Tasks;
using F1Api.Domain.Contract;
using FuncSharp;

namespace F1Api.Handlers;

public interface IDriversHandler
{
    Task<IOption<Driver>> GetDriver(string surname);
    Task<IOption<List<Driver>>> GetDrivers();

    Task<bool> DeleteDriver(string lastName);
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
        return await _repository.GetAllDriversAsync();
    }

    public async Task<bool> DeleteDriver(string lastName)
    {
        return await _repository.DeleteDriverAsync(lastName);
    }
}