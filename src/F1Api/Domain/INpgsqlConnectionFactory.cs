using System.Data.Common;
using Npgsql;

namespace F1Api.Domain;

public interface INpgsqlConnectionFactory
{
    DbConnection GetConnection();
}