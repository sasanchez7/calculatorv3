namespace server.Models
{
    public class SqrtRequest
    {
        public double Number { get; set; }

        public SqrtRequest()
        {

        }

        public SqrtRequest(double Number)
        {
            this.Number = Number;
        }
    }
}
