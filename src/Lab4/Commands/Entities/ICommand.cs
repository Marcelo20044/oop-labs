using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public interface ICommand
{
    public IFileSystem? FileSystem { get; set; }
    ExecutionResult Execute();
}