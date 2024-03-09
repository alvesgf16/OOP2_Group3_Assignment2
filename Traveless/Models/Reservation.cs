namespace Traveless.Models
{
    internal class Reservation(Flight reservedFlight, string customerName, string customerCitizenship)
    {
        public string Code { get; } = GenerateReservationCode();
        public Flight ReservedFlight { get; } = reservedFlight;
        public string CustomerName { get; set; } = customerName;
        public string CustomerCitizenship { get; set; } = customerCitizenship;
        public bool Status { get; set; } = true;

        private static string GenerateReservationCode()
        {
            Random random = new();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "1234567890";
            string result = "";

            int randomLetterPosition = random.Next(letters.Length);
            result += letters[randomLetterPosition];
            while (result.Length < 5)
            {
                int randomNumberPosition = random.Next(numbers.Length);
                result += numbers[randomNumberPosition];
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Code},{ReservedFlight.Code},{CustomerName},{CustomerCitizenship},{Status}";
        }
    }
}
