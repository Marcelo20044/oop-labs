using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Builders;

public class AddresseesGroupBuilder
{
    private List<IAddressee> _addressees = new();

    public AddresseesGroupBuilder AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);
        return this;
    }

    public void Reset()
    {
        _addressees = new List<IAddressee>();
    }

    public AddresseesGroup Build()
    {
        IReadOnlyCollection<IAddressee> addressees = _addressees;
        Reset();
        return new AddresseesGroup(addressees);
    }
}