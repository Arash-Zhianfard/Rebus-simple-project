using Common.Models;
using Rebus.Handlers;
using Rebus.Sagas;

namespace Common
{
    public class OrderSaga : Saga<OrderData>,IAmInitiatedBy<OrderCreated>,        
        IHandleMessages<PaymentFinished>,
        IHandleMessages<InventoryUpdated>,
        IHandleMessages<EmailSent>
    {      
        protected override void CorrelateMessages(ICorrelationConfig<OrderData> config)
        {
            config.Correlate<OnNewOrder>(x => x.OderId, nameof(OrderData.OrderId));
            config.Correlate<PaymentFinished>(x => x.Id, nameof(OrderData.PaymentId));
            config.Correlate<InventoryUpdated>(x => x.Id, nameof(OrderData.InventoryItemId));
            config.Correlate<EmailSent>(x => x.Email, nameof(OrderData.CustomerEmail));
        }

        public Task Handle(OrderCreated message)
        {
            throw new NotImplementedException();
            //call payament 
        }

        public Task Handle(PaymentFinished message)
        {
            throw new NotImplementedException();
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

