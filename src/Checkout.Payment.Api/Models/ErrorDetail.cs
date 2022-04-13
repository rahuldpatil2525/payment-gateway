namespace Checkout.Payment.Api.Models
{
    public class ErrorDetail
    {
        public string RequestId { get; set; }

        public string ErrorType { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

    }
}
