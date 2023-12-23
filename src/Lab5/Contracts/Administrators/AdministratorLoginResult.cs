namespace Contracts.Administrators;

public abstract record AdministratorLoginResult
{
    private AdministratorLoginResult() { }

    public sealed record Success : AdministratorLoginResult;

    public sealed record AdministratorNotFound : AdministratorLoginResult;

    public sealed record InvalidPassword : AdministratorLoginResult;
}