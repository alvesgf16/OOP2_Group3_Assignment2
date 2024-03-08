namespace Traveless.Models;

public class Flight(string code,
                      string airlineName,
                      string originating,
                      string destination,
                      string day,
                      string time,
                      int seats,
                      double cost)
{
    public string Code { get; } = code;
    public string AirlineName { get; } = airlineName;
    public string Originating { get; } = originating;
    public string Destination { get; } = destination;
    public string Day { get; } = day;
    public string Time { get; } = time;
    public int Seats { get; } = seats;
    public double Cost { get; } = cost;

    public override string ToString() => $"{Code}, {AirlineName}, {Originating}, {Destination}, {Day}, {Time}, {Seats}, {Cost}";
}
