using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.ConnectCommandFlagsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.TreeListCommandFlagsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemManagementAppTests
{
    private static readonly ConnectCommandHandler ConnectCommandHandler = new(new ConnectModeFlagHandler());
    private static readonly DisconnectCommandHandler DisconnectCommandHandler = new();
    private static readonly TreeGotoCommandHandler TreeGotoCommandHandler = new();
    private static readonly TreeListCommandHandler TreeListCommandHandler = new(new DepthFlagHandler());
    private static readonly FileShowCommandHandler FileShowCommandHandler = new();
    private static readonly FileMoveCommandHandler FileMoveCommandHandler = new();
    private static readonly FileCopyCommandHandler FileCopyCommandHandler = new();
    private static readonly FileDeleteCommandHandler FileDeleteCommandHandler = new();
    private static readonly FileRenameCommandHandler FileRenameCommandHandler = new();
    private readonly TestFileSystem _testFileSystem = new TestFileSystem();

    public FileSystemManagementAppTests()
    {
        BuildHandlersChain();
        _testFileSystem.CreateFileSystemEntity("/Users/markhvostenko/Documents");
        _testFileSystem.CreateFileSystemEntity("/Users/markhvostenko/Documents/testOopLab");
        _testFileSystem.CreateFileSystemEntity("/Users/markhvostenko/Documents/test");
    }

    [Fact]
    public void ConnectCommandParseAndExecute()
    {
        const string connectRequest = "connect /Users/markhvostenko/Documents -m local";
        var connectRequestIterator = new RequestIterator(connectRequest);
        ICommand? command = ConnectCommandHandler.Handle(connectRequestIterator);
        Assert.NotNull(command);
        command.FileSystem = _testFileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = command.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DisconnectCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string disconnectRequest = "disconnect";
        var disconnectRequestIterator = new RequestIterator(disconnectRequest);
        ICommand? disconnectCommand = ConnectCommandHandler.Handle(disconnectRequestIterator);
        Assert.NotNull(disconnectCommand);
        disconnectCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Final;
        ExecutionResult? actual = disconnectCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TreeGotoCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string treeGotoRequest = "tree goto testOopLab";
        var treeGotoRequestIterator = new RequestIterator(treeGotoRequest);
        ICommand? treeGotoCommand = ConnectCommandHandler.Handle(treeGotoRequestIterator);
        Assert.NotNull(treeGotoCommand);
        treeGotoCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = treeGotoCommand.Execute();

        string expectedDirectoryPath = "/Users/markhvostenko/Documents/testOopLab";
        string? actualDirectoryPath = fileSystem?.CurrentDirectoryPath;

        Assert.Equal(expected, actual);
        Assert.Equal(expectedDirectoryPath, actualDirectoryPath);
    }

    [Fact]
    public void TreeListCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string treeListRequest = "tree list -d 2";
        var treeListRequestIterator = new RequestIterator(treeListRequest);
        ICommand? treeListCommand = ConnectCommandHandler.Handle(treeListRequestIterator);
        Assert.NotNull(treeListCommand);
        treeListCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = treeListCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FileShowCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string fileShowRequest = "file show /Users/markhvostenko/Documents/test -m console";
        var fileShowRequestIterator = new RequestIterator(fileShowRequest);
        ICommand? fileShowCommand = ConnectCommandHandler.Handle(fileShowRequestIterator);
        Assert.NotNull(fileShowCommand);
        fileShowCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = fileShowCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FileMoveCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string fileMoveRequest = "file move test testOopLab";
        var fileMoveRequestIterator = new RequestIterator(fileMoveRequest);
        ICommand? fileMoveCommand = ConnectCommandHandler.Handle(fileMoveRequestIterator);
        Assert.NotNull(fileMoveCommand);
        fileMoveCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = fileMoveCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FileCopyCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string fileCopyRequest = "file copy test /Users/markhvostenko/Documents/testOopLab";
        var fileCopyRequestIterator = new RequestIterator(fileCopyRequest);
        ICommand? fileCopyCommand = ConnectCommandHandler.Handle(fileCopyRequestIterator);
        Assert.NotNull(fileCopyCommand);
        fileCopyCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = fileCopyCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FileRenameCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string fileRenameRequest = "file rename test newTest";
        var fileRenameRequestIterator = new RequestIterator(fileRenameRequest);
        ICommand? fileRenameCommand = ConnectCommandHandler.Handle(fileRenameRequestIterator);
        Assert.NotNull(fileRenameCommand);
        fileRenameCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = fileRenameCommand.Execute();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FileDeleteCommandParseAndExecute()
    {
        IFileSystem? fileSystem = MakeConnection();

        const string fileDeleteRequest = "file delete test";
        var fileDeleteRequestIterator = new RequestIterator(fileDeleteRequest);
        ICommand? fileDeleteCommand = ConnectCommandHandler.Handle(fileDeleteRequestIterator);
        Assert.NotNull(fileDeleteCommand);
        fileDeleteCommand.FileSystem = fileSystem;

        ExecutionResult expected = ExecutionResult.Success;
        ExecutionResult? actual = fileDeleteCommand.Execute();

        Assert.Equal(expected, actual);
    }

    private static void BuildHandlersChain()
    {
        ConnectCommandHandler.NextHandler = DisconnectCommandHandler;
        DisconnectCommandHandler.NextHandler = TreeGotoCommandHandler;
        TreeGotoCommandHandler.NextHandler = TreeListCommandHandler;
        TreeListCommandHandler.NextHandler = FileShowCommandHandler;
        FileShowCommandHandler.NextHandler = FileMoveCommandHandler;
        FileMoveCommandHandler.NextHandler = FileCopyCommandHandler;
        FileCopyCommandHandler.NextHandler = FileDeleteCommandHandler;
        FileDeleteCommandHandler.NextHandler = FileRenameCommandHandler;
    }

    private IFileSystem? MakeConnection()
    {
        const string connectRequest = "connect /Users/markhvostenko/Documents -m local";
        var connectRequestIterator = new RequestIterator(connectRequest);
        ICommand? connectCommand = ConnectCommandHandler.Handle(connectRequestIterator);
        Assert.NotNull(connectCommand);
        connectCommand.FileSystem = _testFileSystem;
        connectCommand.Execute();

        return connectCommand.FileSystem;
    }
}