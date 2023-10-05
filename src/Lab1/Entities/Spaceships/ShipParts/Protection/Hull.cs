using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

public class Hull : BaseProtection
{
    public Hull(StrengthClasses strengthClass)
    {
        int asteroidsCountCanReflect = 1;
        int meteoritesCountCanReflect = 0;
        int spaceWhalesCountCanReflect = 0;

        switch (strengthClass)
        {
            case StrengthClasses.Class1:
                break;
            case StrengthClasses.Class2:
                asteroidsCountCanReflect = 5;
                meteoritesCountCanReflect = 2;
                break;
            case StrengthClasses.Class3:
                asteroidsCountCanReflect = 20;
                meteoritesCountCanReflect = 5;
                break;
        }

        SetStrengthProperties(asteroidsCountCanReflect, meteoritesCountCanReflect, spaceWhalesCountCanReflect, strengthClass);
    }
}