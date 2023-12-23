using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table accounts
    (
        account_number long primary key generated always as identity ,
        account_pin bigint not null ,
        account_balance money not null 
    );

    create table administrators
    (
        administrator_id bigint primary key generated always as identity ,
        administrator_password text not null 
    );

    create table operations
    (
        operation_id bigint primary key generated always as identity ,
        initiator_id bigint references accounts(account_number),
        added_money bigint
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table operations;
    drop table administrators;
    drop table accounts;
    """;
}