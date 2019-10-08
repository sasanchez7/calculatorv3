namespace client.Models
{
    public class AddRequest
    {
        public double[] Addens { get; set; }

        public AddRequest(double[] Addens)
        {
            this.Addens = Addens;
        }
    }
}
