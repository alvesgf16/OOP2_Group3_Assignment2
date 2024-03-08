using Traveless.Models;

namespace Traveless.Services;

public class ReservationManager
{
    private readonly List<Airport> airports = [];
    private readonly List<Flight> flights = [];

    public ReservationManager()
    {
        PopulateAirports();
        PopulateFlights();
    }

    internal List<Airport> Airports => airports;
    internal List<Flight> Flights => flights;

    private void PopulateAirports()
    {
        using var stream = FileSystem.OpenAppPackageFileAsync("airports.csv").Result;
        using var reader = new StreamReader(stream);

        while (reader.ReadLine() != null)
        {
            var airportStr = reader.ReadLine()!;
            var airportData = airportStr.Split(",");

            string airportCode = airportData[0];
            string airportName = airportData[1];

            airports.Add(new Airport(airportCode, airportName));
        }
    }

    private void PopulateFlights()
    {
        using var stream = FileSystem.OpenAppPackageFileAsync("flights.csv").Result;
        using var reader = new StreamReader(stream);

        while (reader.Peek() != -1)
        {
            var flightStr = reader.ReadLine()!;
            var flightData = flightStr.Split(",");

            string flightCode = flightData[0];
            string airlineName = flightData[1];
            string originatingAirport = flightData[2];
            string destination = flightData[3];
            string day = flightData[4];
            string time = flightData[5];
            int seats = int.Parse(flightData[6]);
            double cost = double.Parse(flightData[7]);

            flights.Add(new Flight(flightCode, airlineName, originatingAirport, destination, day, time, seats, cost));

        }
    }

    public List<Flight> GetFlights()
    {
        return flights;
    }

    internal List<Flight> FindFlights(string originating, string destination, string day)
    {
        
        return flights.Where(flight =>
        flight.Originating.Trim().Equals(originating.Trim(), StringComparison.OrdinalIgnoreCase) &&
        flight.Destination.Trim().Equals(destination.Trim(), StringComparison.OrdinalIgnoreCase) &&
        flight.Day.Trim().Equals(day.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
