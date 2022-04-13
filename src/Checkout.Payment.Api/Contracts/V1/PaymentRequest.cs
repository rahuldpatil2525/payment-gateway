namespace Checkout.Payment.Api.Contracts.V1
{
    public class PaymentRequest
    {
        //card number, expiry month/date, amount, currency, and cvv.

        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiaryYear { get; set; }

        public string Cvv { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Reference { get; set; }
    }
}
