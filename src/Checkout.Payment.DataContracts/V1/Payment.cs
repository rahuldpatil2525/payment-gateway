using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Payment.DataContracts.V1
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Status { get; set; }

        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiaryYear { get; set; }

        public string Cvv { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Reference { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified => DateTime.UtcNow;
    }
}
