using Abstractions.Repositories;
using Contracts.Administrators;
using Models.Administrators;

namespace Application.Administrators;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly CurrentAdministratorManager _currentAdministratorManager;

    public AdministratorService(IAdministratorRepository administratorRepository, CurrentAdministratorManager currentAdministratorManager)
    {
        _administratorRepository = administratorRepository;
        _currentAdministratorManager = currentAdministratorManager;
    }

    public AdministratorLoginResult Login(long id, string password)
    {
        Administrator? administrator = _administratorRepository.FindAdministratorById(id).Result;

        if (administrator is null) return new AdministratorLoginResult.AdministratorNotFound();
        if (administrator.Password != password) return new AdministratorLoginResult.InvalidPassword();

        _currentAdministratorManager.Administrator = administrator;
        return new AdministratorLoginResult.Success();
    }
}