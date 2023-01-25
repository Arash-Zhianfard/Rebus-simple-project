namespace OrderService.Models
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}