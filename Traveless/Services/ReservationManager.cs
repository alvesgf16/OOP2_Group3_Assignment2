using System.Text;
using Traveless.Models;

namespace Traveless.Services;

internal class ReservationManager
{
    private readonly List<Airport> airports = [];
    private readonly List<Flight> flights = [];
    private readonly List<Reservation> reservations = [];

    public ReservationManager()
    {
        PopulateAirports();
        PopulateFlights();
    }

    private void PopulateAirports()
    {
        using var stream = FileSystem.OpenAppPackageFileAsync("airports.csv").Result;
        using var reader = new StreamReader(stream);


        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()!;
            var values = line.Split(",");

            string airportCode = values[0];
            string airportName = values[1];

            airports.Add(new Airport(airportCode, airportName));
        }
    }

    private void PopulateFlights()
    {
        using var stream = FileSystem.OpenAppPackageFileAsync("flights.csv").Result;
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()!;
            var values = line.Split(",");

            string flightCode = values[0];
            string airlineName = values[1];
            Airport originatingAirport = airports.Find((airport) => airport.Code == values[2])!;
            Airport destination = airports.Find((airport) => airport.Code == values[3])!;
            string day = values[4];
            string time = values[5];
            int seats = int.Parse(values[6]);
            double cost = double.Parse(values[7]);


            flights.Add(new Flight(flightCode, airlineName, originatingAirport, destination, day, time, seats, cost));

        }
    }

    public Reservation MakeReservation(Flight flight, string travelerName, string travelerCitizenship)
    {
        if (flight is null) throw new ArgumentException();
        if (travelerName is "" or null) throw new ArgumentException();
        if (travelerCitizenship is "" or null) throw new ArgumentException();

        if (flight.Seats == 0) throw new Exception();

        Reservation reservation = new(flight, travelerName, travelerCitizenship);
        reservations.Add(reservation);

        flight.Seats -= 1;

        PersistReservations();

        return reservation;
    }

    private void PersistReservations()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "reservations.bin");
        using FileStream stream = File.Open(path, FileMode.Create);
        using BinaryWriter writer = new(stream, Encoding.UTF8, false);
        reservations.ForEach((reservation) => writer.Write(reservation.ToString()));
    }

    public List<Flight> GetFlights()
    {
        return flights;
    }

    internal List<Flight> FindFlights(string originating, string destination, string day)
    {
        List<Flight> result = flights;

        if (originating is not null) result = result.Where((flight) => flight.Originating.Code.Trim().Equals(originating.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        if (destination is not null) result = result.Where((flight) => flight.Destination.Code.Trim().Equals(destination.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        if (day is not null) result = result.Where((flight) => flight.Day.Trim().Equals(day.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

        return result;
    }
}
