using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<long> CreateAccount(int accountPin)
    {
        const string sql = """
                           insert into accounts (account_pin, account_balance)
                           values (:pin, 0)
                           returning account_number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("pin", accountPin);

        long accountNumber = await command
            .ExecuteNonQueryAsync()
            .ConfigureAwait(false);
        return accountNumber;
    }

    public async Task<Account?> FindAccountByNumber(long accountNumber)
    {
        const string sql = """
                           select * from accounts
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", accountNumber);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false) return null;

        return new Account(
            Number: reader.GetInt64(0),
            Pin: reader.GetInt32(1),
            Balance: reader.GetInt64(2));
    }

    public async Task UpdateBalance(long accountNumber, long newBalance)
    {
        const string sql = """
                           update accounts
                           set account_balance = :newBalance
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", accountNumber);
        command.AddParameter("newBalance", newBalance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<long> GetBalance(long accountNumber)
    {
        const string sql = """
                           select account_balance
                           from accounts
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", accountNumber);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        return await reader.ReadAsync().ConfigureAwait(false) is false ? 0 : reader.GetInt64(0);
    }
}