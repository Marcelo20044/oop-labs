using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repositories;
using Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class OperationsRepoMock : IOperationRepository
{
    public Task CreateOperation(long initiatorId, long balanceDifference)
    {
        return Task.CompletedTask;
    }

    public IAsyncEnumerable<Operation> GetAllOperationsByAccountNumber(long accountNumber)
    {
        return AsyncEnumerable.Empty<Operation>();
    }
}