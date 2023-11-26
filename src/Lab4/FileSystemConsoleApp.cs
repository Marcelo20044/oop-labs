using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class FileSystemConsoleApp
{
    private static readonly ConnectCommandHandler ConnectCommandHandler = new();
    private static readonly DisconnectCommandHandler DisconnectCommandHandler = new();
    private static readonly TreeGotoCommandHandler TreeGotoCommandHandler = new();
    private static readonly TreeListCommandHandler TreeListCommandHandler = new();
    private static readonly FileShowCommandHandler FileShowCommandHandler = new();
    private static readonly FileMoveCommandHandler FileMoveCommandHandler = new();
    private static readonly FileCopyCommandHandler FileCopyCommandHandler = new();
    private static readonly FileDeleteCommandHandler FileDeleteCommandHandler = new();
    private static readonly FileRenameCommandHandler FileRenameCommandHandler = new();

    public static void Run()
    {
        BuildChain();

        IFileSystem? currentFileSystem = null;
        while (true)
        {
            string request = Console.ReadLine() ?? string.Empty;
            var requestIterator = new RequestIterator(request);
            ICommand? command = ConnectCommandHandler.Handle(requestIterator);

            if (command is null) break;
            if (command is ConnectCommand)
            {
                currentFileSystem = command.FileSystem;
            }
            else
            {
                command.FileSystem = currentFileSystem;
            }

            ExecutionResult result = command.Execute();
            if (result is ExecutionResult.Fail or ExecutionResult.Final) break;
        }
    }

    private static void BuildChain()
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
}