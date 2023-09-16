namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class RouteReport
{
    public RouteReport(RouteResult result, int travelTime = 0, int spentFuel = 0)
    {
        Result = result;
        TravelTime = travelTime;
        SpentFuel = spentFuel;
    }

    public RouteResult Result { get; }
    public int TravelTime { get; }
    public int SpentFuel { get; }
}