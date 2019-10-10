namespace server.Models
{
    public class DivResponse
    {
        public double Quotient { get; set; }
        public double Remainder { get; set; }

        public DivResponse(double Quotient, double Remainder)
        {
            this.Quotient = Quotient;
            this.Remainder = Remainder;
        }
    }
}
