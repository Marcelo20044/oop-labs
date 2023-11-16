using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Decorators;

public class MessageLoggerDecorator : IAddressee
{
    private readonly ILogger _logger;
    private readonly IAddressee _addressee;

    public MessageLoggerDecorator(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log(message.ToString());
        _addressee.ReceiveMessage(message);
    }
}