namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public interface IFileSystem
{
    string? ConnectionPath { get; }
    string? CurrentDirectoryPath { get; }

    void Connect(string path);
    void Disconnect();
    void TreeGoto(string path);
    void TreeList(int depth);
    void FileShow(string path);
    void FileMove(string sourcePath, string destinationPath);
    void FileCopy(string sourcePath, string destinationPath);
    void FileDelete(string path);
    void FileRename(string path, string newName);
}