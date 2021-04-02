using System.Data.Entity;
using BestOilMVP.Models;

namespace BestOilMVP.Data
{
    class FuelContext:DbContext
    {
        public FuelContext():base("FuelDb2")
        {
            Fuels.Add(new Fuel()
            {
                Name = "AI92",
                Price = 1.95,
            });

            Fuels.Add(new Fuel()
            {
                Name = "AI95",
                Price = 1.10,
            });

            Fuels.Add(new Fuel()
            {
                Name = "Diesel",
                Price = 0.95,
            });
        }

        public DbSet<Fuel> Fuels { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Fuels.Add(new Fuel()
        //    {
        //        Name = "AI92",
        //        Price = 1.95,
        //    });

        //    Fuels.Add(new Fuel()
        //    {
        //        Name = "AI95",
        //        Price = 1.10,
        //    });

        //    Fuels.Add(new Fuel()
        //    {
        //        Name = "Diesel",
        //        Price = 0.95,
        //    });
        //}
    }
}
