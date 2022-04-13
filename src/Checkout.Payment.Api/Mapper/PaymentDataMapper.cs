using Checkout.Payment.Api.Models;
using PaymentData = Checkout.Payment.DataContracts.V1.Payment;

namespace Checkout.Payment.Api.Mapper
{
    public interface IPaymentDataMapper
    {
        PaymentData Map(PaymentCore paymentCore);
    }

    public class PaymentDataMapper : IPaymentDataMapper
    {
        public PaymentData Map(PaymentCore paymentCore)
        {
            return new PaymentData()
            {
                Amount = paymentCore.Amount,
                CardNumber = paymentCore.CardNumber,
                Currency = paymentCore.Currency,
                Cvv = paymentCore.Cvv,
                ExpiaryYear = paymentCore.ExpiaryYear,
                ExpiryMonth = paymentCore.ExpiryMonth,
                Reference = paymentCore.Reference,
                Status = paymentCore.Status
            };
        }
    }
}
