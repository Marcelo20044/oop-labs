namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

public class Hull : Protection
{
    public Hull(StrengthClasses strengthStrengthClass)
    {
        switch (strengthStrengthClass)
        {
            case StrengthClasses.Class1:
                SetStrengthProperties(2, 1, 0);
                break;
            case StrengthClasses.Class2:
                SetStrengthProperties(10, 3, 0);
                break;
            case StrengthClasses.Class3:
                SetStrengthProperties(40, 10, 1);
                break;
        }
    }
}