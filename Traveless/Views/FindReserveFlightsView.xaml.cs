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

    private ReservationManager ReservationManager { get; } = new ReservationManager();



    private void FindFlightsButton_Clicked(object sender, EventArgs e)
	{

        //var flights = new ObservableCollection<Flight>(reservationManager.FindFlights(from.Text, to.Text, day.Text));
        var flights = new ObservableCollection<Flight>(ReservationManager.FindFlights(from.Text, to.Text, day.Text));
        listOfFlights.ItemsSource = flights;
        listOfFlights.SelectedIndex = 0;
    }

        
    }
}