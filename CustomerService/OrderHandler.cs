using Common.Models;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace CustomerService
{
    public class CreateOrderHandler : Saga<OrderData>, IHandleMessages<OnNewOrder>
    {
        private readonly IBus _bus;

        public CreateOrderHandler(IBus bus)
        {
            _bus = bus;
        }
        public async Task Handle(OnNewOrder message)
        {
            var order = CreateOrder(message);
            await _bus.Send(new OnCreatePayment() { OrderId = order });
            
            
        }

        private int CreateOrder(OnNewOrder message)
        {
            /*
             implimentation detial for creating Order 
            */

            return new Random().Next(0, 100);
        }
    }

    public class CancelOrderHandler : IHandleMessages<OnNewOrder>
    {
        public Task Handle(OnNewOrder message)
        {
            throw new NotImplementedException();
        }
    }
}
