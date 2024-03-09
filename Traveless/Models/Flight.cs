namespace Traveless.Models;

internal class Flight(string code,
                      string airlineName,
                      Airport originating,
                      Airport destination,
                      string day,
                      string time,
                      int seats,
                      double cost)
{
    public string Code { get; } = code;
    public string AirlineName { get; } = airlineName;
    public Airport Originating { get; } = originating;
    public Airport Destination { get; } = destination;
    public string Day { get; } = day;
    public string Time { get; } = time;
    public int Seats { get; set; } = seats;
    public double Cost { get; } = cost;

    public override string ToString() => $"{Code}, {AirlineName}, {Originating.Code}, {Destination.Code}, {Day}, {Time}, {Seats}, {Cost}";
}
