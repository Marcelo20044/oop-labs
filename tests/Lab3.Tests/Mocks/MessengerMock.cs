using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class MessengerMock : IMessenger
{
    public string WrittenText { get; private set; } = string.Empty;
    public void WriteText(string text)
    {
        WrittenText = text;
    }
}