using Contracts.Accounts;
using Models.Accounts;

namespace Application.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}