using Checkout.Payment.Api.Composers;
using Checkout.Payment.Api.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Payment.Api.Installer
{
    public static class MapperInstaller
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IPaymentCoreMapper, PaymentCoreMapper>();
            services.AddSingleton<IPaymentDataMapper, PaymentDataMapper>();
            services.AddSingleton<IPaymentResponseComposer, PaymentResponseComposer>();

            return services;
        }
    }
}
