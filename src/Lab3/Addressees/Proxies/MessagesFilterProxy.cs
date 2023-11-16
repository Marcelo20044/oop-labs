using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Proxies;

public class MessagesFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _acceptableImportanceLevel;

    public MessagesFilterProxy(IAddressee addressee, ImportanceLevel acceptableImportanceLevel)
    {
        _addressee = addressee;
        _acceptableImportanceLevel = acceptableImportanceLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _acceptableImportanceLevel)
            _addressee.ReceiveMessage(message);
    }
}