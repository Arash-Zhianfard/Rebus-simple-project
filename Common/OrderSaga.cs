using Common.Models;
using Rebus.Sagas;

namespace Common
{
    public class OrderSaga : Saga<OrderData>
    {
        protected override void CorrelateMessages(ICorrelationConfig<OrderData> config)
        {
            config.Correlate<OnOrderCreate>(x => x.Id, nameof(OrderData.OrderId));
            config.Correlate<OnCreatePayment>(x => x.Id, nameof(OrderData.PaymentId));
            config.Correlate<OnUpdateInventory>(x => x.Id, nameof(OrderData.InventoryItemId));
            config.Correlate<OnSendEmail>(x => x.Id, nameof(OrderData.EmailId));
        }
    }
}

