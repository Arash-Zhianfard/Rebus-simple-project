using Common.Models;
using Rebus.Handlers;

namespace PaymentService
{
    internal class PaymentHandler : IHandleMessages<OnNewOrder>
    {
        public Task Handle(OnNewOrder message)
        {
            throw new NotImplementedException();
        }
    }
}
