using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Administrators;
using Npgsql;

namespace DataAccess.Repositories;

public class AdministratorRepository : IAdministratorRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdministratorRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Administrator?> FindAdministratorById(long id)
    {
        const string sql = """
                            select *
                            from administrators
                            where administrato_id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
        {
            return null;
        }

        return new Administrator(
            Id: reader.GetInt64(0),
            Password: reader.GetString(1));
    }
}