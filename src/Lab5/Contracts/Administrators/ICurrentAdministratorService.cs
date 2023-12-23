using Models.Administrators;

namespace Contracts.Administrators;

public interface ICurrentAdministratorService
{
    Administrator? Administrator { get; }
}