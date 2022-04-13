namespace Checkout.Payment.Api.Models
{
    public class PaymentResult
    {
        public PaymentResult(PaymentCore payment)
        {
            Payment = payment;
            Success = true;
        }

        public PaymentResult(ErrorDetail error)
        {
            Error = error;
            Success = false;
        }

        public PaymentCore Payment { get; }

        public ErrorDetail Error { get; }

        public bool Success { get; }

        public static PaymentResult ErrorPaymentResult(string message, string requestId)
        {
            var error = new ErrorDetail()
            {
                ErrorMessage = message,
                RequestId = requestId,
            };

            return new PaymentResult(error);
        }

    }
}
