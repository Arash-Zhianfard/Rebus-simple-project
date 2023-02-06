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
            config.Correlate<OnNewOrder>(x => x.OderId, nameof(OrderData.OrderId));
            config.Correlate<PaymentFinished>(x => x.Id, nameof(OrderData.PaymentId));
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
            //call Email Service
            var emailClient = _httpClientFactory.CreateClient("Email");
            await emailClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(new { message.PaymentId })));
        }

        public Task Handle(EmailSent message)
        {
            throw new NotImplementedException();
        }

        public Task Handle(InventoryUpdated message)
        {
            throw new NotImplementedException();
        }
    }
}

