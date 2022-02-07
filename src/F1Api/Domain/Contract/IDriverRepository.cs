using FuncSharp;

namespace F1Api.Domain.Contract;

public interface IDriverRepository
{
    Task SaveDriverAsync<T>(T item);
    Task<IOption<Driver>> GetDriverAsync(string surname);
    Task<IEnumerable<T>> GetAllDriversAsync<T>();
    Task DeleteDriverAsync<T>(T item);
}