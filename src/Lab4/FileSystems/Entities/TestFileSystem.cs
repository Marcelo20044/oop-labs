using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class TestFileSystem : IFileSystem
{
    private readonly HashSet<string> _directoriesAndFiles = new();
    public string? ConnectionPath { get; private set; }
    public string? CurrentDirectoryPath { get; private set; }

    public void Connect(string path)
    {
        if (!_directoriesAndFiles.Contains(path)) throw new DirectoryNotFoundException(path);
        ConnectionPath = CurrentDirectoryPath = path;
    }

    public void Disconnect()
    {
        ConnectionPath = CurrentDirectoryPath = null;
    }

    public void TreeGoto(string path)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(path)) throw new DirectoryNotFoundException(path);

        CurrentDirectoryPath = path;
    }

    public void TreeList(int depth)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
    }

    public void FileShow(string path)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(path)) throw new FileNotFoundException(path);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(sourcePath)) throw new FileNotFoundException(sourcePath);

        int lastIndex = sourcePath.LastIndexOf('/');
        string newPath = string.Concat(destinationPath, sourcePath[lastIndex..]);
        _directoriesAndFiles.Remove(sourcePath);
        _directoriesAndFiles.Add(newPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(sourcePath)) throw new FileNotFoundException(sourcePath);

        int lastIndex = sourcePath.LastIndexOf('/');
        string newPath = string.Concat(destinationPath, sourcePath[lastIndex..]);
        _directoriesAndFiles.Add(newPath);
    }

    public void FileDelete(string path)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(path)) throw new FileNotFoundException(path);

        _directoriesAndFiles.Remove(path);
    }

    public void FileRename(string path, string newName)
    {
        if (ConnectionPath is null) throw new FileSystemNotConnectedException();
        if (!_directoriesAndFiles.Contains(path)) throw new FileNotFoundException(path);

        int lastIndex = path.LastIndexOf('/');
        string newPath = string.Concat(path.AsSpan(0, lastIndex + 1), newName);

        _directoriesAndFiles.Remove(path);
        _directoriesAndFiles.Add(newPath);
    }

    public void CreateFileSystemEntity(string path)
    {
        _directoriesAndFiles.Add(path);
    }
}