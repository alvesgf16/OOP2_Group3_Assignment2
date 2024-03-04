using Traveless.Views;

namespace Traveless
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
            Routing.RegisterRoute(nameof(FindUpdateReservationView), typeof(FindUpdateReservationView));
            Routing.RegisterRoute(nameof(FindReserveFlightsView), typeof(FindReserveFlightsView));
        }
    }
}
