namespace server.Models
{
    public class DivRequest
    {
        public double Dividend { get; set; }
        public double Divisor { get; set; }

        public DivRequest()
        {

        }

        public DivRequest(double Dividend, double Divisor)
        {
            this.Dividend = Dividend;
            this.Divisor = Divisor;
        }
    }
}
