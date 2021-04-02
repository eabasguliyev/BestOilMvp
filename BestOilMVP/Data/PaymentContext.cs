using System.Data.Entity;
using BestOilMVP.Models;

namespace BestOilMVP.Data
{
    class PaymentContext:DbContext
    {
        public PaymentContext():base("PaymentDb2")
        {

        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
