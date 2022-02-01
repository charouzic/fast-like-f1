using Dapper;
using F1Api.Domain.Contract;
using Npgsql;

namespace F1Api.Domain;

public class DriverRepository: IDriverRepository
{
    private readonly IConfiguration _configuration;

    public DriverRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    // TODO: add async keyword
    public async Task<T> GetDriverAsync<T>(string surname)
    {
        // TODO: set it up so it retrieves the dbConnectionString more cleanly
        using (var conn = new NpgsqlConnection(_configuration.GetValue<string>($"MySettings:DbConnection")))
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