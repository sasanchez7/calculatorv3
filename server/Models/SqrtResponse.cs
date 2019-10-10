namespace server.Models
{
    public class SqrtResponse
    {
        public double Square { get; set; }

        public SqrtResponse(double Square)
        {
            this.Square = Square;
        }
    }
}
