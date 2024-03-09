using System.Collections.ObjectModel;
using Traveless.Models;
using Traveless.Services;

namespace Traveless.Views;

public partial class FindReserveFlightsView : ContentPage
{
	public FindReserveFlightsView()
	{
		InitializeComponent();
	}

    private ReservationManager reservationManager { get; } = new ReservationManager();



    private void FindFlightsButton_Clicked(object sender, EventArgs e)
	{

        //var flights = new ObservableCollection<Flight>(reservationManager.FindFlights(from.Text, to.Text, day.Text));
        var flights = new ObservableCollection<Flight>(reservationManager.FindFlights(from.Text, to.Text, day.Text));
        listOfFlights.ItemsSource = flights;
        System.Diagnostics.Debug.WriteLine(from.Text);
        System.Diagnostics.Debug.WriteLine(to.Text);
        System.Diagnostics.Debug.WriteLine(day.Text);
        System.Diagnostics.Debug.WriteLine(flights.Count());

        
    }
}