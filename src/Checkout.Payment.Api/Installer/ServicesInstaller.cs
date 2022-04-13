using Checkout.Payment.Api.BankSimulator;
using Checkout.Payment.Api.Composers;
using Checkout.Payment.Api.Services;
using Checkout.Payment.Api.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Payment.Api.Installer
{
    public static class ServicesInstaller
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IBankGateway, BankGateway>();
            services.AddSingleton<IPaymentRequestValidator, PaymentRequestValidator>();

            return services;
        }
    }
}
