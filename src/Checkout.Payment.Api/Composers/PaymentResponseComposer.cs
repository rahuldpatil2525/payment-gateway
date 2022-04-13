using Checkout.Payment.Api.Contracts.V1;
using Checkout.Payment.Api.Models;

namespace Checkout.Payment.Api.Composers
{
    public interface IPaymentResponseComposer
    {
        PaymentResponse Compose(PaymentCore payment);
    }

    public class PaymentResponseComposer : IPaymentResponseComposer
    {
        public PaymentResponse Compose(PaymentCore payment)
        {
            return new PaymentResponse()
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Id = payment.Id,
                Reference = payment.Reference,
                ProcessedOn = payment.ProcessedOn,
                Status = payment.Status
            };
        }
    }
}
