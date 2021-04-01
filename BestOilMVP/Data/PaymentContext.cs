using BestOilMVP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOilMVP.Data
{
    class PaymentContext:DbContext
    {
        public PaymentContext():base("PaymentDb")
        {

        }

        public DbSet<Payment> Payments { get; set; }
    }
}
