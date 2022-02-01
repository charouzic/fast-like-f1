namespace F1Api.Domain.Contract;

public interface IRepository
{
    Task SaveAsync<T>(T item);
    Task<T> GetAsync<T>(string search);
    Task<IEnumerable<T>> GetAllAsync<T>();
    Task DeleteAsync<T>(T item);
}