namespace Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;

public class RouteReport
{
    public RouteReport(RouteResult result, double travelTime = 0, double spentFuel = 0, double spentMoney = 0)
    {
        Result = result;
        TravelTime = travelTime;
        SpentFuel = spentFuel;
        SpentMoney = spentMoney;
    }

    public RouteResult Result { get; }
    public double TravelTime { get; }
    public double SpentFuel { get; }
    public double SpentMoney { get; }
}