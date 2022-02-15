using Dapper;
using F1Api.Domain.Contract;
using FuncSharp;
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
    public async Task<IOption<Driver>> GetDriverAsync(string surname)
    {
        // TODO: set it up so it retrieves the dbConnectionString more cleanly
        using (var conn = new NpgsqlConnection(Settings.Get("DbConnection", _configuration)))
        {
            // TODO: replace the * with the fields that are actually present in the db so I'm not retrieving too many items
            var plainDriver = await conn.QueryAsync<Driver>(
                //removed dateofbirth column because of parsing
                $"SELECT id, firstname, lastname, country, placeofbirth, team, numberofpodiums, firstseason, note FROM public.drivers WHERE lastname = '{surname}'");
            
            return Option.Create(plainDriver.FirstOrDefault());
        }
    }
    
    // TODO: add async keyword
    public async Task<IOption<List<Driver>>> GetAllDriversAsync()
    {
        using (var conn = new NpgsqlConnection(Settings.Get("DbConnection", _configuration)))
        {
            var plainDriver = await conn.QueryAsync<Driver>(
                //removed dateofbirth column because of parsing
                $"SELECT id, firstname, lastname, country, placeofbirth, team, numberofpodiums, firstseason, note FROM public.drivers");

            return Option.Create(plainDriver.ToList());
        }
    }

    // TODO: add async keyword
    public Task SaveDriverAsync<T>(T item)
    {
        throw new NotImplementedException();
    }

    // TODO: add async keyword
    public async Task<bool> DeleteDriverAsync(string lastName)
    {
        using (var conn = new NpgsqlConnection(Settings.Get("DbConnection", _configuration)))
        {
            var deletedDriver = await conn.ExecuteAsync(
                $"DELETE FROM public.drivers WHERE lastname = '{lastName}'");
            
            return deletedDriver.Match(
                0, _ => false,
                _ => true);
        }
    }
}