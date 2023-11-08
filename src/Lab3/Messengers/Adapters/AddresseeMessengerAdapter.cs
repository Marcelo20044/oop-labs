using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Adapters;

public class AddresseeMessengerAdapter : IAddressee
{
    private readonly IMessenger _messenger;

    public AddresseeMessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.WriteText(message.ToString());
    }
}