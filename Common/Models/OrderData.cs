using Rebus.Sagas;

namespace Common.Models
{
    public class OrderData : ISagaData
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        public bool OrderCreated { get; set; }
        public bool PayementFinished { get; set; }
        public bool InventoryItemUpdated { get; set; }
        public bool EmailSent { get; set; }
        public Guid OrderId { get; set; }
        public int PaymentId { get; set; }
        public int InventoryItemId { get; set; }
        public int CustomerEmail { get; set; }
        public bool OrderCompleted => OrderCreated && InventoryItemUpdated && PayementFinished && EmailSent;
    }
}
