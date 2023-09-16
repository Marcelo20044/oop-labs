namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity;

public class RouteReport
{
    public RouteReport(RouteResult result, int travelTime = 0, int spentFuel = 0, int spentMoney = 0)
    {
        Result = result;
        TravelTime = travelTime;
        SpentFuel = spentFuel;
        SpentMoney = spentMoney;
    }

    public RouteResult Result { get; }
    public int TravelTime { get; }
    public int SpentFuel { get; }
    public int SpentMoney { get; }
}