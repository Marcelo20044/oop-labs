using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationRepository
{
    Task CreateOperation(long initiatorId, long balanceDifference);
    IAsyncEnumerable<Operation> GetAllOperationsByAccountNumber(long accountNumber);
}