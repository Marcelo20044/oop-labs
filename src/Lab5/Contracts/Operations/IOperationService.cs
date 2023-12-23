using Models.Operations;

namespace Contracts.Operations;

public interface IOperationService
{
    IEnumerable<Operation> ShowOperations(long accountNumber);
}