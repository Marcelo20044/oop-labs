using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

public class Deflector : BaseProtection
{
    public Deflector(StrengthClasses strengthClass)
    {
        int asteroidsCountCanReflect = 2;
        int meteoritesCountCanReflect = 1;
        int spaceWhalesCountCanReflect = 0;

        switch (strengthClass)
        {
            case StrengthClasses.Class1:
                break;
            case StrengthClasses.Class2:
                asteroidsCountCanReflect = 10;
                meteoritesCountCanReflect = 3;
                break;
            case StrengthClasses.Class3:
                asteroidsCountCanReflect = 40;
                meteoritesCountCanReflect = 10;
                spaceWhalesCountCanReflect = 1;
                break;
        }

        SetStrengthProperties(asteroidsCountCanReflect, meteoritesCountCanReflect, spaceWhalesCountCanReflect, strengthClass);
    }

    public int AntimatterFlaresCountReflect { get; set; }
}