namespace client.Models
{
    public class SubRequest
    {
        public double Minuend { get; set; }
        public double substrahend { get; set; }

        public SubRequest(double Minuend, double substrahend)
        {
            this.Minuend = Minuend;
            this.substrahend = substrahend;
        }
    }
}