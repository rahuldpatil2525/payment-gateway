using Checkout.Payment.Api.Contracts.V1;

namespace Checkout.Payment.Api.Validators
{
    public interface IPaymentRequestValidator
    {
        bool Validate(PaymentRequest request);
    }

    public class PaymentRequestValidator : IPaymentRequestValidator
    {
        public bool Validate(PaymentRequest request)
        {
            //Add validation logic to verify sender request is valid.
            //for time being I have added just one check but we can add other checks.
            //Also Add logging to track rejection.

            if (request.ExpiryMonth < 0 || request.ExpiryMonth > 12)
            {
                return false;
            }

            return true;
        }
    }
}
