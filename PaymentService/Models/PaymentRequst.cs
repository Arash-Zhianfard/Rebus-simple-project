using System.Runtime.Versioning;

namespace PaymentService.Models
{
    public class PaymentRequst
    {
        public int ProductId { get; set; }        
        public int CustomerId { get; set; }
    }
}