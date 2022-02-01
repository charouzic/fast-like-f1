using Dapper;
using F1Api.Domain.Contract;
using Npgsql;

namespace F1Api.Domain;

public class DriverRepository: IDriverRepository
{
    // TODO: add async keyword
    public async Task<T> GetDriverAsync<T>(string surname)
    {
        // TODO: set up the db
        using (var conn = new NpgsqlConnection("connection string"))
        {
            // TODO: replace the * with the fields that are actually present in the db so I'm not retrieving too many items
            var plainDriver = await conn.QueryAsync<dynamic>($"SELECT * FROM drivers WHERE surname = {surname}");
        }
        // TODO: map the response to return just one driver
        
        throw new NotImplementedException();
    }
    
    // TODO: add async keyword
    public Task<IEnumerable<T>> GetAllDriversAsync<T>()
    {
        throw new NotImplementedException();
    }
    
    // TODO: add async keyword
    public Task SaveDriverAsync<T>(T item)
    {
        throw new NotImplementedException();
    }

    // TODO: add async keyword
    public Task DeleteDriverAsync<T>(T item)
    {
        throw new NotImplementedException();
    }
}