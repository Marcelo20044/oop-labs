using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Adapters;

public class AddresseeDisplayAdapter : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public Color Color { get; set; }
    public void ReceiveMessage(Message message)
    {
        _display.DisplayText(message.ToString(), Color);
    }
}