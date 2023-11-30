using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class LocalFileSystem : IFileSystem
{
    public string? ConnectionPath { get; private set; }
    public string? CurrentDirectoryPath { get; private set; }

    public void Connect(string path)
    {
        if (!Directory.Exists(path)) throw new DirectoryNotFoundException(path);
        ConnectionPath = CurrentDirectoryPath = path;
    }

    public void Disconnect()
    {
        ConnectionPath = CurrentDirectoryPath = null;
    }

    public void TreeGoto(string path)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!Directory.Exists(path)) throw new DirectoryNotFoundException(path);

        CurrentDirectoryPath = path;
    }

    public void TreeList(int depth)
    {
        TreeListConsoleWrite(
            CurrentDirectoryPath ?? throw new FileSystemNotConnectedException(),
            depth);
    }

    public void FileShow(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException(path);

        Console.WriteLine(File.ReadAllText(path));
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath)) throw new FileNotFoundException(sourcePath);

        string fileName = Path.GetFileName(sourcePath);
        string destinationFilePath = Path.Combine(destinationPath, fileName);

        if (!File.Exists(destinationFilePath))
        {
            File.Move(sourcePath, destinationFilePath);
        }
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath)) throw new FileNotFoundException(sourcePath);

        string fileName = Path.GetFileName(sourcePath);
        string destinationFilePath = Path.Combine(destinationPath, fileName);

        if (!File.Exists(destinationFilePath))
        {
            File.Copy(sourcePath, destinationFilePath);
        }
    }

    public void FileDelete(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException(path);

        File.Delete(path);
    }

    public void FileRename(string path, string newName)
    {
        if (!File.Exists(path)) throw new FileNotFoundException(path);

        string? directory = Path.GetDirectoryName(path);
        string newFilePath = Path.Combine(
            directory ?? throw new ArgumentException(path),
            newName);

        if (!File.Exists(newFilePath))
        {
            File.Move(path, newFilePath);
        }
    }

    private static void TreeListConsoleWrite(string path, int depth, int currentDepth = 0)
    {
        if (currentDepth > depth) return;

        Console.WriteLine($"{new string(' ', currentDepth * 2)}{Path.GetFileName(path)}//:");

        foreach (string file in Directory.GetFiles(path))
        {
            Console.WriteLine($"{new string(' ', (currentDepth + 1) * 2)}{Path.GetFileName(file)}");
        }

        foreach (string directory in Directory.GetDirectories(path))
        {
            TreeListConsoleWrite(directory, depth, currentDepth + 1);
        }
    }
}