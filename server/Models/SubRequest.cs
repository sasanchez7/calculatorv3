namespace server.Models
{
    public class SubRequest
    {
        public double Minuend { get; set; }
        public double substrahend { get; set; }

        public SubRequest()
        {

        }

        public SubRequest(double Minuend, double substrahend)
        {
            this.Minuend = Minuend;
            this.substrahend = substrahend;
        }
    }
}