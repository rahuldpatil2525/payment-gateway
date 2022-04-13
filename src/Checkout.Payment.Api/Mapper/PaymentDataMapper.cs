using Checkout.Payment.Api.Extensions;
using Checkout.Payment.Api.Models;
using PaymentData = Checkout.Payment.DataContracts.V1.Payment;

namespace Checkout.Payment.Api.Mapper
{
    public interface IPaymentDataMapper
    {
        PaymentData Map(PaymentCore paymentCore);

        PaymentCore Map(PaymentData payment);
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

        public PaymentCore Map(PaymentData payment)
        {
            return new PaymentCore()
            {
                Amount = payment.Amount,
                CardNumber = payment.CardNumber.Mask(),
                Currency = payment.Currency,
                Cvv = payment.Cvv,
                ExpiaryYear = payment.ExpiaryYear,
                ExpiryMonth = payment.ExpiryMonth,
                Reference = payment.Reference,
                Status = payment.Status,
                Id = payment.Id,
                ProcessedOn = payment.DateModified
            };
        }
    }
}
