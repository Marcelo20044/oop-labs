using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseeUser : IAddressee
{
    public AddresseeUser(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
    public Dictionary<Message, bool> Messages { get; } = new();
    public void ReceiveMessage(Message message)
    {
        const bool messageRead = false;
        Messages.Add(message, messageRead);
    }

    public void ReadMessage(Message message)
    {
        if (!Messages.TryGetValue(message, out bool messageRead)) return;
        if (messageRead) throw new MessageHasAlreadyBeenReadException(message.Header);
        Messages[message] = true;
    }
}