using System;

namespace Checkout.Payment.Api.Contracts.V1
{
    public class HistoryPaymentResponse: PaymentResponse
    {
        public string CardNumber { get; set; }
    }
}
