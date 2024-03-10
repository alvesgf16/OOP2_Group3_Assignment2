using System.Collections.ObjectModel;
using Traveless.Models;
using Traveless.Services;

namespace Traveless.Views;

public partial class FindReserveFlightsView : ContentPage
{
    private ReservationManager reservationManager = new();
	
    public FindReserveFlightsView()
	{
		InitializeComponent();
	}


    private void FindFlightsButton_Clicked(object sender, EventArgs e)
	{

        //var flights = new ObservableCollection<Flight>(reservationManager.FindFlights(from.Text, to.Text, day.Text));
        var flights = new ObservableCollection<Flight>(reservationManager.FindFlights(from.Text, to.Text, day.Text));
        listOfFlights.ItemsSource = flights;
        listOfFlights.SelectedIndex = 0;
    }

    private void ReserveButton_Clicked(object sender, EventArgs e)
    {
        Reservation reservation = reservationManager.MakeReservation((Flight)listOfFlights.SelectedItem, name.Text, citizenship.Text);
        reservationCode.Text = reservation.Code;
    }
}