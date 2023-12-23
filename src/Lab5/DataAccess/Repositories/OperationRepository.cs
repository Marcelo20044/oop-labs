using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task CreateOperation(long initiatorId, long balanceDifference)
    {
        const string sql = """
                           insert into operations (initiator_id, added_money)
                           values (:initiator, :addedMoney)
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("initiator", initiatorId);
        command.AddParameter("addedMoney", balanceDifference);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async IAsyncEnumerable<Operation> GetAllOperationsByAccountNumber(long accountNumber)
    {
        const string sql = """
                           select * from operations
                           where initiator = :initiator;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("initiator", accountNumber);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false) yield break;

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            yield return new Operation(
                Id: reader.GetInt64(0),
                InitiatorId: reader.GetInt64(1),
                BalanceDifference: reader.GetInt64(3));
        }
    }
}