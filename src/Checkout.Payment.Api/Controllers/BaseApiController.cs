using Checkout.Payment.Api.Constants;
using Checkout.Payment.Api.Contracts.V1;
using Checkout.Payment.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Payment.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected ActionResult ErrorResponse(ErrorDetail error)
        {
            if (error.ErrorCode == ErrorCodes.InternalServerError || error.ErrorCode == ErrorCodes.DependencyFailed)
                return InternalServerError(error);

            return BadRequestResponse(error);
        }

        protected ActionResult InvalidRequest(string requestId)
        {
            var error = new ErrorResponse(requestId, "request_invalid", "request_invalid", "Payment request is invalid.");
            return StatusCode(422, error);
        }

        protected ActionResult InternalServerError(ErrorDetail error)
        {
            var response = new ErrorResponse(error.RequestId,error.ErrorType, error.ErrorCode, error.ErrorMessage);
            return StatusCode(500, response);
        }

        protected ActionResult NotFound(string requestId)
        {
            var response = new ErrorResponse(requestId, "Not Found", "Not-Found","Payment Details for Requested Id not found." );
            return StatusCode(400, response);
        }

        protected ActionResult BadRequestResponse(ErrorDetail error)
        {
            var response = new ErrorResponse(error.RequestId, error.ErrorType, error.ErrorCode, error.ErrorMessage);
            return BadRequest(response);
        }
    }
}
