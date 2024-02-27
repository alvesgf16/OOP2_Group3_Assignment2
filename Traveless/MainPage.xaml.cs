using Traveless.Services;

namespace Traveless
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ReservationManager reservationManager = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            flightExample.Text = reservationManager.Flights[count].ToString();
            airportExample.Text = reservationManager.Airports[count].FullName;
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

        }
    }

}
