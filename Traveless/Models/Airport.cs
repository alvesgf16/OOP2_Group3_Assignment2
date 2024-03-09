namespace Traveless.Models
{
    internal class Airport(string code, string fullName)
    {
        public string Code { get; } = code;
        public string FullName { get; } = fullName;

        public override string ToString() => $"{Code}, {FullName}";
    }
}
