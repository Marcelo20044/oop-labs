using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseesGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public AddresseesGroup(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
            addressee.ReceiveMessage(message);
    }
}