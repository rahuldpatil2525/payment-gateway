using System.Threading.Tasks;
using Checkout.Payment.Api.Models;

namespace Checkout.Payment.Api.BankSimulator
{
    public interface IBankGateway
    {
        Task ProcessPaymentAsync(PaymentCore payment);
    }

    public class BankGateway : IBankGateway
    {
        public Task ProcessPaymentAsync(PaymentCore payment)
        {
            payment.SetStatus("Processed");
            return Task.CompletedTask;
        }
    }
}
