namespace server.Models
{
    public class MultRequest
    {
        public double[] Factors { get; set; }

        public MultRequest()
        {

        }

        public MultRequest(double[] Factors)
        {
            this.Factors = Factors;
        }
    }
}