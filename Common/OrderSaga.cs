using Common.Models;
using Newtonsoft.Json;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace Common
{
    public class OrderSaga : Saga<OrderData>, IAmInitiatedBy<OrderCreated>,
        IHandleMessages<PaymentFinished>,
        IHandleMessages<InventoryUpdated>,
        IHandleMessages<EmailSent>
    {
        private readonly IBus _bus;
        IHttpClientFactory _httpClientFactory;
        public OrderSaga(IBus bus, IHttpClientFactory httpClientFactory)
        {
            _bus = bus;
            _httpClientFactory = httpClientFactory;
        }

        protected override void CorrelateMessages(ICorrelationConfig<OrderData> config)
        {
            config.Correlate<OrderCreated>(x => x.OrderId, nameof(OrderData.OrderId));
            config.Correlate<PaymentFinished>(x => x.PaymentId, nameof(OrderData.PaymentId));
            config.Correlate<InventoryUpdated>(x => x.Id, nameof(OrderData.InventoryItemId));
            config.Correlate<EmailSent>(x => x.Email, nameof(OrderData.CustomerEmail));
        }

        public async Task Handle(OrderCreated message)
        {
            Data.OrderCreated = true;
            //call payament
            var paymentClient = _httpClientFactory.CreateClient("payment");
            await paymentClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(new { message.OrderId })));
        }

        public async Task Handle(PaymentFinished message)
        {
            Data.PaymentId = message.PaymentId;
            Data.PayementFinished = true;
            //call Inventory Service
            var inventoryClient = _httpClientFactory.CreateClient("Inventory");
            await inventoryClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(new { message.PaymentId })));
        }

        public async Task Handle(InventoryUpdated message)
        {
            Data.InventoryItemId = message.Id;
            Data.InventoryItemUpdated = true;
            //call Inventory Service
            var inventoryClient = _httpClientFactory.CreateClient("Email");
            await inventoryClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(new { message.Id })));
        }

        public async Task Handle(EmailSent message)
        {
            Data.CustomerEmail = message.Email;
            Data.EmailSent = true;

            if (Data.OrderCreated)
            {
                MarkAsComplete();
            }
        }        
    }
}

