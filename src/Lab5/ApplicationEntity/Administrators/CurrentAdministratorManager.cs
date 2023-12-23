using Contracts.Administrators;
using Models.Administrators;

namespace Application.Administrators;

public class CurrentAdministratorManager : ICurrentAdministratorService
{
    public Administrator? Administrator { get; set; }
}