using Common.Models;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace CustomerService
{
    public class CreateOrderHandler : IHandleMessages<OnNewOrder>
    {
        private readonly IBus _bus;

        public CreateOrderHandler(IBus bus)
        {
            _bus = bus;
        }
        public async Task Handle(OnNewOrder message)
        {
            var order = CreateOrder(message);
            await _bus.Reply(new OrderCreated() { OrderId = order });
        }

        private int CreateOrder(OnNewOrder message)
        {
            /*
               Implementation detial 
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
