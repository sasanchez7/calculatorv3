namespace client.Models
{
    public class MultRequest
    {
        public double[] Factors { get; set; }

        public MultRequest(double[] Factors)
        {
            this.Factors = Factors;
        }
    }
}