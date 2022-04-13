using Checkout.Payment.Api.Contracts.V1;
using Checkout.Payment.Api.Models;

namespace Checkout.Payment.Api.Mapper
{
    public interface IPaymentCoreMapper
    {
        PaymentCore Map(PaymentRequest paymentRequest);
    }

    public class PaymentCoreMapper : IPaymentCoreMapper
    {
        public PaymentCore Map(PaymentRequest paymentRequest)
        {
            return new PaymentCore()
            {
                Amount = paymentRequest.Amount,
                CardNumber = paymentRequest.CardNumber,
                Currency = paymentRequest.Currency,
                Cvv = paymentRequest.Cvv,
                ExpiaryYear = paymentRequest.ExpiaryYear,
                ExpiryMonth = paymentRequest.ExpiryMonth,
                Reference = paymentRequest.Reference
            };
        }
    }
}
