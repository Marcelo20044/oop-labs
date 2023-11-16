using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; }
    public IAddressee Addressee { get; }

    public void SendMessage(Message message)
    {
        Addressee.ReceiveMessage(message);
    }
}