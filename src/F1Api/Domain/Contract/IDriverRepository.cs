using FuncSharp;

namespace F1Api.Domain.Contract;

public interface IDriverRepository
{
    Task SaveDriverAsync<T>(T item);
    Task<IOption<Driver>> GetDriverAsync(string surname);
    Task<IOption<List<Driver>>> GetAllDriversAsync();
    Task<bool> DeleteDriverAsync(string lastName);
}