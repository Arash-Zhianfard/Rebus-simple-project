using Common.Models;
using Rebus.Handlers;

namespace PaymentService
{
    internal class PaymentHandler : IHandleMessages<OnOrderCreate>
    {
        public Task Handle(OnOrderCreate message)
        {
            throw new NotImplementedException();
        }
    }
}
