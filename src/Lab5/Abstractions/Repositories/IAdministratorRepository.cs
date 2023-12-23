using Models.Administrators;

namespace Abstractions.Repositories;

public interface IAdministratorRepository
{
    Task<Administrator?> FindAdministratorById(long id);
}