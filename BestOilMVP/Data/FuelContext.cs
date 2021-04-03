using System.Data.Entity;
using System.Linq;
using BestOilMVP.Models;

namespace BestOilMVP.Data
{
    class FuelContext:DbContext
    {
        public FuelContext():base("FuelDb2")
        {
            LoadData();
        }

        public DbSet<Fuel> Fuels { get; set; }

        private void LoadData()
        {
            if (Fuels.Count() == 3)
                return;

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

            this.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //
        //}
    }
}
