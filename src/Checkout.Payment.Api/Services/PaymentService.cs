using System;
using System.Threading.Tasks;
using Checkout.Payment.Api.BankSimulator;
using Checkout.Payment.Api.Constants;
using Checkout.Payment.Api.Contracts.V1;
using Checkout.Payment.Api.Mapper;
using Checkout.Payment.Api.Models;
using Checkout.Payment.Api.Repositories;
using Microsoft.Extensions.Logging;

namespace Checkout.Payment.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentResult> MakePaymentAsync(PaymentRequest request);

        Task<PaymentResult> GetPaymentAsync(string paymentReference);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentCoreMapper _paymentCoreMapper;
        private readonly IBankGateway _bankGateway;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IPaymentCoreMapper paymentCoreMapper,
            IBankGateway bankGateway,
            ILogger<PaymentService> logger)
        {
            _paymentRepository = paymentRepository;
            _paymentCoreMapper = paymentCoreMapper;
            _bankGateway = bankGateway;
            _logger = logger;
        }

        public async Task<PaymentResult> GetPaymentAsync(string paymentReference)
        {
            var paymentCore = await _paymentRepository.GetPaymentAsync(paymentReference);

            return new PaymentResult(paymentCore);
        }

        public async Task<PaymentResult> MakePaymentAsync(PaymentRequest request)
        {
            try
            {
                var corePayment = _paymentCoreMapper.Map(request);

                await _bankGateway.ProcessPaymentAsync(corePayment);

                await _paymentRepository.RecordPaymentAsync(corePayment);

                return new PaymentResult(corePayment);
            }
            //Add custom/specific exceptions
            catch (Exception ex)
            {
                _logger.LogError(LogId.PaymentProcessFailedGeneralException, ex, ex.Message, request.Reference);

                return PaymentResult.ErrorPaymentResult("Failed to Process Payment", request.Reference);
            }
        }
    }
}
