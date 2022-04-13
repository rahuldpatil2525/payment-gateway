using System;

namespace Checkout.Payment.Api.Models
{
    public class PaymentCore
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiaryYear { get; set; }

        public string Cvv { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Reference { get; set; }

        public DateTime ProcessedOn { get; set; }

        public void SetStatus(string status)
        {
            Status = status;
        }

        public void SetKeyAttributes(string id, DateTime dateModified)
        {
            Id = id;
            ProcessedOn = dateModified;
        }
    }
}
