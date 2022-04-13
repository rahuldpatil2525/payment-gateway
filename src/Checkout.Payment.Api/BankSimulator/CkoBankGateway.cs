using System.Threading.Tasks;
using Checkout.Payment.Api.Models;

namespace Checkout.Payment.Api.BankSimulator
{
    public interface IBankGateway
    {
        Task ProcessPaymentAsync(PaymentCore payment);
    }

    /// <summary>
    /// I have just added mock class to process payments. 
    /// to more details, I can inject http client and mock the client in the dependency and add mocking in the unit test to test the behaviour 
    /// even we can add authentication and token generation 
    /// </summary>
    public class BankGateway : IBankGateway
    {
        public Task ProcessPaymentAsync(PaymentCore payment)
        {
            payment.SetStatus("Processed");
            return Task.CompletedTask;
        }
    }
}
