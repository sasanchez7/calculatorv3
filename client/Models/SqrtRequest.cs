namespace client.Models
{
    public class SqrtRequest
    {
        public double Number { get; set; }
        public SqrtRequest(double Number)
        {
            this.Number = Number;
        }
    }
}
