namespace Checkout.Payment.Api.Contracts.V1
{
    public class ErrorResponse
    {
        public ErrorResponse(string requestId, string errorType, string errorCode, string errorMessage)
        {
            RequestId = requestId;
            ErrorType = errorType;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public string ErrorCode { get; }

        public string ErrorMessage { get; }

        public string RequestId { get; }

        public string ErrorType { get; }

    }
}
