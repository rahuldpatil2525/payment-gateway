using Microsoft.EntityFrameworkCore;

namespace Checkout.Payment.Api.Database
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {

        }

        public DbSet<Payment.DataContracts.V1.Payment> Payments { get; set; }
    }
}
