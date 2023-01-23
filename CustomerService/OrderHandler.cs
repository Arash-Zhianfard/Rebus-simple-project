using Common.Models;
using Rebus.Handlers;

namespace CustomerService
{
    public class CreateOrderHandler : IHandleMessages<OnOrderCreate>
    {
        public Task Handle(OnOrderCreate message)
        {
            throw new NotImplementedException();
        }
    }

    public class CancelOrderHandler : IHandleMessages<OnOrderCreate>
    {
        public Task Handle(OnOrderCreate message)
        {
            throw new NotImplementedException();
        }
    }
}
