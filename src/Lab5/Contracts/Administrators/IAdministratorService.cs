namespace Contracts.Administrators;

public interface IAdministratorService
{
    AdministratorLoginResult Login(long id, string password);
}