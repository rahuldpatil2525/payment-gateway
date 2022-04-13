using Checkout.Payment.Api.Configuration;
using Checkout.Payment.Api.Database;
using Checkout.Payment.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Payment.Api.Installer
{
    public static class DatabaseInstaller
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var paymentDbConfig = configuration.GetSection("PaymentDbSettings").Get<PaymentDbConfig>();

            //services.AddDbContext<PaymentContext>(options => options.UseSqlServer(paymentDbConfig.ConnectionString, providerOptions => providerOptions.EnableRetryOnFailure()));
            services.AddDbContext<PaymentContext>(opt => opt.UseInMemoryDatabase(paymentDbConfig.Database));

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
