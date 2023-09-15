namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

public class Deflector : Protection
{
    public Deflector(StrengthClasses strengthStrengthClass, bool isPhotonDeflectorSet = false)
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
            case StrengthClasses.NoClass:
                SetStrengthProperties(0, 0, 0);
                break;
        }

        if (isPhotonDeflectorSet)
        {
            AntimatterFlareCountReflect = 3;
        }
    }

    public int AntimatterFlareCountReflect { get; }
}