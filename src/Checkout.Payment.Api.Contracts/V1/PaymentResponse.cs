using System;

namespace Checkout.Payment.Api.Contracts.V1
{
    public class PaymentResponse
    {
        public string  Id { get; set; }
        
        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }

        public string Reference { get; set; }

        public DateTime  ProcessedOn { get; set; }
    }
}
