using System.Threading.Tasks;
using Checkout.Payment.Api.Composers;
using Checkout.Payment.Api.Constants;
using Checkout.Payment.Api.Contracts.V1;
using Checkout.Payment.Api.Services;
using Checkout.Payment.Api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Checkout.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentResponseComposer _responseComposer;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentRequestValidator _requestValidator;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(
            IPaymentResponseComposer responseComposer,
            IPaymentService paymentService,
            IPaymentRequestValidator requestValidator,
            ILogger<PaymentController> logger)
        {
            _responseComposer = responseComposer;
            _paymentService = paymentService;
            _requestValidator = requestValidator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PaymentRequest paymentRequest)
        {
            _logger.LogInformation(LogId.LogPaymentRequest, paymentRequest.Reference);

            if (!_requestValidator.Validate(paymentRequest))
            {
                _logger.LogError(LogId.PaymentRequestValidationFailed, paymentRequest.Reference);

                return InvalidRequest(paymentRequest.Reference);
            }

            var result = await _paymentService.MakePaymentAsync(paymentRequest);

            if (!result.Success)
            {
                return ErrorResponse(result.Error);
            }

            var response = _responseComposer.Compose(result.Payment);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string paymentReference)
        {
            var result = await _paymentService.GetPaymentAsync(paymentReference);

            if (result == null)
            {
                return NotFound(paymentReference);
            }

            var response = _responseComposer.ComposeHistory(result.Payment);

            return Ok(response);
        }
    }
}
