using Itmo.ObjectOrientedProgramming.Lab3.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class LoggerMock : ILogger
{
    public string LoggedText { get; private set; } = string.Empty;
    public void Log(string text)
    {
        LoggedText = text;
    }
}