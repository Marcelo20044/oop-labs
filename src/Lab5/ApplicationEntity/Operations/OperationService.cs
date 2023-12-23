using Abstractions.Repositories;
using Contracts.Operations;
using Models.Operations;

namespace Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;

    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }

    public IEnumerable<Operation> ShowOperations(long accountNumber)
    {
        return _operationRepository.GetAllOperationsByAccountNumber(accountNumber).ToBlockingEnumerable();
    }
}